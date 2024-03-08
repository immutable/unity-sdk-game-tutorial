// Copyright (c) Immutable Australia Pty Ltd 2018 - 2024
// SPDX-License-Identifier: MIT
pragma solidity 0.8.19;

import "@imtbl/contracts/contracts/token/erc721/preset/ImmutableERC721.sol";

// The Runner fox you use to play the game
contract RunnerFox is ImmutableERC721 {
    uint256 private _currentTokenId = 0;

    constructor(
        address owner,
        string memory baseURI,
        string memory contractURI,
        address operatorAllowlist,
        address receiver,
        uint96 feeNumerator
    )
        ImmutableERC721(
            owner,
            "Immutable Runner Fox", // name
            "IMRC", // symbol
            baseURI,
            contractURI,
            operatorAllowlist,
            receiver,
            feeNumerator
        )
    {}

    // Allows minter to mint the next token to a specified address
    function mintNextToken(address to) external onlyRole(MINTER_ROLE) returns (uint256) {
        uint256 tokenId = ++_currentTokenId;
        _mintByID(to, tokenId);
        return tokenId;
    }

    // Allows minter to mint number of tokens specified to the address
    function mintNextTokenByQuantity(address to, uint256 quantity) external onlyRole(MINTER_ROLE) {
        for (uint256 i = 0; i < quantity; i++) {
            _mintByID(to, ++_currentTokenId);
        }
    }
}