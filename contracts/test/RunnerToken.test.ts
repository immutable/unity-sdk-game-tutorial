import { ethers } from "hardhat";
import { expect } from "chai";
import { RunnerToken, OperatorAllowlist__factory, RunnerToken__factory, ImmutableERC721, ImmutableERC721__factory } from "../typechain-types";

describe("RunnerToken", function () {
  let contract: RunnerToken;
  let skinContract: ImmutableERC721;

  beforeEach(async function () {
    // get owner (first account)
    const [owner] = await ethers.getSigners();

    // deploy OperatorAllowlist contract
    const OperatorAllowlist = await ethers.getContractFactory(
      "OperatorAllowlist"
    ) as OperatorAllowlist__factory;
    const operatorAllowlist = await OperatorAllowlist.deploy(owner.address);

    // deploy RunnerSkin contract
    const ImmutableERC721 = await ethers.getContractFactory("ImmutableERC721") as ImmutableERC721__factory;
    skinContract = await ImmutableERC721.deploy(
      owner.address, // owner
      "Immutable Runner Skin", // name
      "IMRS", // symbol
      "https://immutable.com/", // baseURI
      "https://immutable.com/", // contractURI
      operatorAllowlist.address, // operator allowlist contract
      owner.address, // royalty recipient
      ethers.BigNumber.from("2000") // fee numerator
    );
    await skinContract.deployed();

    // deploy RunnerToken contract
    const RunnerToken = await ethers.getContractFactory("RunnerToken") as RunnerToken__factory;
    contract = await RunnerToken.deploy(skinContract.address);
    await contract.deployed();

    // grant owner the minter role
    await contract.grantMinterRole(owner.address);
    // grant owner the minter role
    await contract.grantBurnerRole(owner.address);
    // grant the token contract to mint skins
    await skinContract.grantMinterRole(contract.address);
  });

  it("Should be deployed with the correct arguments", async function () {
    expect(await contract.name()).to.equal("Immutable Runner Token");
    expect(await contract.symbol()).to.equal("IMR");
  });

  it("Account with minter role should be able to mint tokens", async function () {
    const [owner, recipient] = await ethers.getSigners();

    await contract.connect(owner).mint(recipient.address, 1);
    expect(await contract.balanceOf(recipient.address)).to.equal(1);

    await contract.connect(owner).mint(recipient.address, 2);
    expect(await contract.balanceOf(recipient.address)).to.equal(3);
  });

  it("Account without minter role should not be able to mint NFTs", async function () {
    const [_, acc1] = await ethers.getSigners();
    const minterRole = await contract.MINTER_ROLE();
    await expect(
      contract.connect(acc1).mint(acc1.address, 1)
    ).to.be.revertedWith(
      `AccessControl: account ${acc1.address.toLowerCase()} is missing role ${minterRole}`
    );
  });

  it("Account with burner role should be able to burn tokens", async function () {
    const [owner, recipient] = await ethers.getSigners();

    await contract.connect(owner).mint(recipient.address, 2);
    expect(await contract.balanceOf(recipient.address)).to.equal(2);

    await contract.connect(owner).burn(recipient.address, 1);
    expect(await contract.balanceOf(recipient.address)).to.equal(1);
  });

  it("Account without burner role should not be able to burn NFTs", async function () {
    const [owner, acc1, recipient] = await ethers.getSigners();
    const burnerRole = await contract.BURNER_ROLE();

    await contract.connect(owner).mint(recipient.address, 2);
    expect(await contract.balanceOf(recipient.address)).to.equal(2);

    await expect(
      contract.connect(acc1).burn(recipient.address, 1)
    ).to.be.revertedWith(
      `AccessControl: account ${acc1.address.toLowerCase()} is missing role ${burnerRole}`
    );
  });

  it("Account with three tokens can craft skin", async function () {
    const [owner, recipient] = await ethers.getSigners();

    const threeTokens = ethers.BigNumber.from(3).mul(ethers.BigNumber.from(10).pow(await contract.decimals()));
    await contract.connect(owner).mint(recipient.address, threeTokens);
    expect(await contract.balanceOf(recipient.address)).to.equal(threeTokens);

    await contract.connect(recipient).craftSkin();
    expect(await contract.balanceOf(recipient.address)).to.equal(0);
    expect(await skinContract.balanceOf(recipient.address)).to.equal(1);
    expect(await skinContract.ownerOf(await skinContract.mintBatchByQuantityThreshold())).to.equal(recipient.address);
  });

  it("Account with not enough tokens should not be able to craft skin", async function () {
    const [owner, recipient] = await ethers.getSigners();

    const twoTokens = ethers.BigNumber.from(2).mul(ethers.BigNumber.from(10).pow(await contract.decimals()));
    await contract.connect(owner).mint(recipient.address, twoTokens);
    expect(await contract.balanceOf(recipient.address)).to.equal(twoTokens);

    await expect(contract.connect(recipient).craftSkin()).to.be.revertedWith(
      'craftSkin: Caller does not have enough tokens'
    );
  });

  it("Token contract should not be able to craft skin without skin contract minter role", async function () {
    const [owner, recipient] = await ethers.getSigners();
    await skinContract.revokeMinterRole(contract.address);

    const threeTokens = ethers.BigNumber.from(3).mul(ethers.BigNumber.from(10).pow(await contract.decimals()));
    await contract.connect(owner).mint(recipient.address, threeTokens);
    expect(await contract.balanceOf(recipient.address)).to.equal(threeTokens);

    await expect(contract.connect(recipient).craftSkin()).to.be.revertedWith(
      `AccessControl: account ${contract.address.toLowerCase()} is missing role ${await skinContract.MINTER_ROLE()}`
    );
    expect(await contract.balanceOf(recipient.address)).to.equal(threeTokens);
  });

  it("Only admin account can grant minter and burner role", async function () {
    const [owner, recipient] = await ethers.getSigners();

    await contract.connect(owner).grantMinterRole(recipient.address);
    expect(await contract.hasRole(await contract.MINTER_ROLE(), recipient.address)).to.equal(true);

    await contract.connect(owner).grantBurnerRole(recipient.address);
    expect(await contract.hasRole(await contract.BURNER_ROLE(), recipient.address)).to.equal(true);
  });

  it("Non-admin accounts cannot grant minter and burner role", async function () {
    const [_, acc1, recipient] = await ethers.getSigners();
    const adminRole = await contract.DEFAULT_ADMIN_ROLE();

    await expect(
      contract.connect(acc1).grantMinterRole(recipient.address)
    ).to.be.revertedWith(
      `AccessControl: account ${acc1.address.toLowerCase()} is missing role ${adminRole}`
    );

    await expect(
      contract.connect(acc1).grantBurnerRole(recipient.address)
    ).to.be.revertedWith(
      `AccessControl: account ${acc1.address.toLowerCase()} is missing role ${adminRole}`
    );
  });
});