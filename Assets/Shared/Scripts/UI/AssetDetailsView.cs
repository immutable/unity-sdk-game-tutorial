#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using Cysharp.Threading.Tasks;
using HyperCasual.Core;
using Immutable.Orderbook.Api;
using Immutable.Orderbook.Client;
using Immutable.Orderbook.Model;
using Immutable.Passport;
using Immutable.Passport.Model;
using Immutable.Api.Api;
using Immutable.Api.Model;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using ERC1155Item = Immutable.Orderbook.Model.ERC1155Item;
using ERC20Item = Immutable.Orderbook.Model.ERC20Item;
using ERC721Item = Immutable.Orderbook.Model.ERC721Item;

namespace HyperCasual.Runner
{
    public class AssetDetailsView : View
    {
        [SerializeField] private HyperCasualButton m_BackButton;
        [SerializeField] private BalanceObject m_Balance;

        [SerializeField] private ImageUrlObject m_Image;
        [SerializeField] private TextMeshProUGUI m_NameText;
        [SerializeField] private TextMeshProUGUI m_DescriptionText;

        // Market
        [SerializeField] private TextMeshProUGUI m_FloorPriceText;

        [SerializeField] private TextMeshProUGUI m_LastTradePriceText;

        // Details
        [SerializeField] private TextMeshProUGUI m_TokenIdText;
        [SerializeField] private TextMeshProUGUI m_CollectionText;
        [SerializeField] private TextMeshProUGUI m_ContractTypeText;

        // Attributes
        [SerializeField] private Transform m_AttributesListParent;
        [SerializeField] private AttributeView m_AttributeObj;

        // Listing
        [SerializeField] private TextMeshProUGUI m_AmountText;
        [SerializeField] private HyperCasualButton m_SellButton;
        [SerializeField] private HyperCasualButton m_CancelButton;
        [SerializeField] private GameObject m_Progress;

        [SerializeField] private CustomDialog m_CustomDialog;

        private readonly List<AttributeView> m_Attributes = new();

        private readonly StacksApi m_StacksApi;
        private readonly OrderbookApi m_OrderbookApi;

        private NFTBundle m_Asset;
        private string? m_ListingId;

        public AssetDetailsView()
        {
            m_OrderbookApi = new OrderbookApi(new Configuration { BasePath = Config.BASE_URL });
            m_StacksApi = new StacksApi(new Immutable.Api.Client.Configuration { BasePath = Config.BASE_URL });
        }

        private void OnEnable()
        {
            m_AttributeObj.gameObject.SetActive(false); // Disable the template attribute object

            m_BackButton.RemoveListener(OnBackButtonClick);
            m_BackButton.AddListener(OnBackButtonClick);
            m_SellButton.RemoveListener(OnSellButtonClicked);
            m_SellButton.AddListener(OnSellButtonClicked);
            m_CancelButton.RemoveListener(OnCancelButtonClicked);
            m_CancelButton.AddListener(OnCancelButtonClicked);

            // Gets the player's balance
            m_Balance.UpdateBalance();
        }

        /// <summary>
        ///     Cleans up data
        /// </summary>
        private void OnDisable()
        {
            m_NameText.text = "";
            m_DescriptionText.text = "";
            m_TokenIdText.text = "";
            m_CollectionText.text = "";
            m_ContractTypeText.text = "";
            m_AmountText.text = "";
            m_FloorPriceText.text = "";
            m_LastTradePriceText.text = "";

            m_Asset = null;
            ClearAttributes();
        }

        /// <summary>
        ///     Initialises the UI based on the asset.
        /// </summary>
        /// <param name="asset">The asset to display.</param>
        public async void Initialise(NFTBundle asset)
        {
            m_Asset = asset;

            m_NameText.text = m_Asset.NftWithStack.ContractType.ToUpper() switch
            {
                "ERC721" => $"{m_Asset.NftWithStack.Name} #{m_Asset.NftWithStack.TokenId}",
                "ERC1155" => $"{m_Asset.NftWithStack.Name} x{m_Asset.NftWithStack.Balance}",
                _ => m_NameText.text
            };

            m_DescriptionText.text = m_Asset.NftWithStack.Description;
            m_DescriptionText.gameObject.SetActive(!string.IsNullOrEmpty(m_Asset.NftWithStack.Description));

            // Details
            m_TokenIdText.text = $"Token ID: {m_Asset.NftWithStack.TokenId}";
            m_CollectionText.text = $"Collection: {m_Asset.NftWithStack.ContractAddress}";
            m_ContractTypeText.text = $"Contract type: {m_Asset.NftWithStack.ContractType.ToUpper()}";

            // Clear existing attributes
            ClearAttributes();
            
            // Populate attributes
            foreach (var attribute in m_Asset.NftWithStack.Attributes)
            {
                var newAttribute = Instantiate(m_AttributeObj, m_AttributesListParent);
                newAttribute.gameObject.SetActive(true);
                newAttribute.Initialise(attribute);
                m_Attributes.Add(newAttribute);
            }

            // Check if asset is listed
            m_ListingId = m_Asset.Listings.Count > 0 ? m_Asset.Listings[0].ListingId : null;
            m_SellButton.gameObject.SetActive(m_ListingId == null);
            m_CancelButton.gameObject.SetActive(m_ListingId != null);

            // Price if it's listed
            m_AmountText.text = "-";
            if (m_Asset.Listings.Count > 0)
            {
                Listing listing = m_Asset.Listings[0];
                var amount = listing.PriceDetails.Amount.Value;
                var quantity = (decimal)BigInteger.Parse(amount) / (decimal)BigInteger.Pow(10, 18);
                m_AmountText.text = m_Asset.NftWithStack.ContractType.ToUpper() switch
                {
                    "ERC721" => $"{quantity} IMR",
                    "ERC1155" => $"{listing.PriceDetails.Amount} for {quantity} IMR",
                    _ => m_AmountText.text
                };
            }
            else
            {
                m_AmountText.text = "Not listed";
            }

            GetMarketData();

#pragma warning disable CS4014
            m_Image.LoadUrl(m_Asset.NftWithStack.Image);
#pragma warning restore CS4014
        }

        private async void GetMarketData()
        {
            if (m_Asset.Market?.FloorListing != null)
            {
                var quantity = (decimal)BigInteger.Parse(m_Asset.Market.FloorListing.PriceDetails.Amount.Value) /
                               (decimal)BigInteger.Pow(10, 18);
                m_FloorPriceText.text = $"Floor price: {quantity} IMR";
            }
            else
            {
                m_FloorPriceText.text = "Floor price: N/A";
            }

            if (m_Asset.Market?.LastTrade?.PriceDetails?.Count > 0)
            {
                var quantity = (decimal)BigInteger.Parse(m_Asset.Market.LastTrade.PriceDetails[0].Amount.Value) /
                               (decimal)BigInteger.Pow(10, 18);
                m_LastTradePriceText.text = $"Last trade price: {quantity} IMR";
            }
            else
            {
                m_LastTradePriceText.text = "Last trade price: N/A";
            }
        }

        /// <summary>
        ///     Handles the click event for the sell button.
        /// </summary>
        private async void OnSellButtonClicked()
        {
            var (priceResult, price) = await m_CustomDialog.ShowDialog(
                $"List {m_Asset.NftWithStack.Name} for sale",
                "Enter your price below (in IMR):",
                "Confirm",
                "Cancel",
                true
            );

            if (!priceResult) return;
            
            var normalizedPrice = Math.Floor(decimal.Parse(price) * (decimal)BigInteger.Pow(10, 18));
                
            var amountToSell = "1";
            if (m_Asset.NftWithStack.ContractType.ToUpper() == ERC1155Item.TypeEnum.ERC1155.ToString())
            {

                var (amountResult, amount) = await m_CustomDialog.ShowDialog(
                    $"How many {m_Asset.NftWithStack.Name} do you want to sell?",
                    "Enter the amount below:",
                    "Confirm",
                    "Cancel",
                    true
                );

                if (!amountResult) return;

                amountToSell = amount;
            }
            
            m_SellButton.gameObject.SetActive(false);
            m_Progress.gameObject.SetActive(true);

            var listingId = await Sell($"{normalizedPrice}", amountToSell);
            Debug.Log($"Sell complete: Listing ID: {listingId}");

            m_SellButton.gameObject.SetActive(listingId == null);
            m_CancelButton.gameObject.SetActive(listingId != null);
                
            if (listingId != null)
            {
                m_AmountText.text = m_Asset.NftWithStack.ContractType.ToUpper() switch
                {
                    "ERC721" => $"{price} IMR",
                    "ERC1155" => $"{amountToSell} for {price} IMR",
                    _ => m_AmountText.text
                };
            }
            else
            {
                m_AmountText.text = "Not listed";
            }

            m_Progress.gameObject.SetActive(false);
        }

        private async UniTask<PrepareListing200Response> PrepareListing(
            string nftTokenAddress, string tokenId, string price, string erc20TokenAddress, string amountToSell)
        {
            Debug.Log("Prepare listing...");
            
            // Create the NFT listing based on its contract type (ERC721 or ERC1155)
            var sell = m_Asset.NftWithStack.ContractType.ToUpper() switch
            {
                var type when type == ERC1155Item.TypeEnum.ERC1155.ToString() =>
                    new PrepareListingRequestSell(new ERC1155Item(amountToSell, nftTokenAddress, tokenId)),
                var type when type == ERC721Item.TypeEnum.ERC721.ToString() => 
                    new PrepareListingRequestSell(new ERC721Item(nftTokenAddress, tokenId)),

                _ => throw new Exception($"Cannot sell {m_Asset.NftWithStack.ContractType.ToUpper()}")
            };
            
            // Create the ERC20 token item for the purchase
            var buy = new ERC20Item(price, erc20TokenAddress);

            // Prepare the listing for sale
            return await m_OrderbookApi.PrepareListingAsync(new PrepareListingRequest
            (
                makerAddress: SaveManager.Instance.WalletAddress,
                sell: sell,
                buy: new PrepareListingRequestBuy(buy)
            ));
        }

        private async UniTask SignAndSubmitApproval(PrepareListing200Response prepareListingResponse)
        {
            Debug.Log("Sign and submit approval...");
            
            var transactionAction =
                prepareListingResponse.Actions.FirstOrDefault(action => action.ActualInstance.GetType() == typeof(TransactionAction));
            
            // Send approval transaction if it is required
            if (transactionAction != null)
            {
                var tx = transactionAction.GetTransactionAction();
                var transactionResponse = await Passport.Instance.ZkEvmSendTransactionWithConfirmation(
                    new TransactionRequest
                    {
                        to = tx.PopulatedTransactions.To,
                        data = tx.PopulatedTransactions.Data,
                        value = "0"
                    });

                if (transactionResponse.status != "1") throw new Exception("Failed to sign and submit approval");
            }
        }

        private async UniTask<string> SignListing(PrepareListing200Response prepareListingResponse)
        {
            Debug.Log("Sign listing...");
            
            var signableAction =
                prepareListingResponse.Actions.FirstOrDefault(action => action.ActualInstance.GetType() == typeof(SignableAction));

            if (signableAction == null) throw new Exception("No listing to sign");

            var message = signableAction.GetSignableAction().Message;

            // Use Unity Passport package to sign typed data function to sign the listing payload
            return await Passport.Instance.ZkEvmSignTypedDataV4(
                      JsonConvert.SerializeObject(message, Formatting.Indented));
        }

        /// <summary>
        ///     Prepares the listing for the asset.
        /// </summary>
        /// <param name="price">The price of the asset in smallest unit.</param>
        /// <param name="amountToSell">The amount to sell. This is only used for ERC1155</param>
        /// <returns>The listing ID is asset was successfully listed</returns>
        private async UniTask<string?> Sell(string price, string amountToSell)
        {
            try
            {
                var prepareListingResponse =
                    await PrepareListing(m_Asset.NftWithStack.ContractAddress, m_Asset.NftWithStack.TokenId, $"{price}",
                        Contract.TOKEN, amountToSell);

                await SignAndSubmitApproval(prepareListingResponse);

                var signature = await SignListing(prepareListingResponse);

                var listingId = await ListAsset(signature, prepareListingResponse);
                Debug.Log($"Listing ID: {listingId}");

                await ConfirmListingStatus(listingId, "ACTIVE");

                return listingId;
            }
            catch (ApiException e)
            {
                Debug.LogError($"API error: {e.Message} (Status Code: {e.ErrorCode})");
                Debug.LogError($"API error content: {e.ErrorContent}");
                Debug.LogError(e.StackTrace);
            }
            catch (Exception ex)
            {
                Debug.Log($"Failed to sell: {ex.Message}");
                Debug.LogError(ex.StackTrace);
                await m_CustomDialog.ShowDialog("Failed to sell", ex.Message, "OK");
            }

            return null;
        }

        /// <summary>
        ///     Finalises the listing of the asset.
        /// </summary>
        /// <param name="signature">The signature for the listing.</param>
        /// <param name="preparedListing">The prepared listing data.</param>
        private async UniTask<string> ListAsset(string signature,
            PrepareListing200Response preparedListing)
        {
            Debug.Log("List asset...");
            
            var createListingResponse = await m_OrderbookApi.CreateListingAsync(
                new CreateListingRequest
                (
                    new List<FeeValue>(),
                    preparedListing.OrderComponents,
                    preparedListing.OrderHash,
                    signature
                ));

            return createListingResponse.Result.Id;
        }

        /// <summary>
        ///     Cancels the listing of the asset.
        /// </summary>
        private async void OnCancelButtonClicked()
        {
            if (m_ListingId == null) return;
            
            Debug.Log($"Cancel listing {m_ListingId}");

            m_CancelButton.gameObject.SetActive(false);
            m_Progress.gameObject.SetActive(true);

            try
            {
                var request = new CancelOrdersOnChainRequest(
                    accountAddress: SaveManager.Instance.WalletAddress,
                    orderIds: new List<string> { m_ListingId });
                var response = await m_OrderbookApi.CancelOrdersOnChainAsync(request);

                if (response?.CancellationAction.PopulatedTransactions.To != null)
                {
                    var transactionResponse = await Passport.Instance.ZkEvmSendTransactionWithConfirmation(
                        new TransactionRequest
                        {
                            to = response.CancellationAction.PopulatedTransactions.To, // Immutable seaport contract
                            data = response.CancellationAction.PopulatedTransactions.Data, // fd9f1e10 cancel
                            value = "0"
                        });

                    if (transactionResponse.status == "1")
                    {
                        // Validate that listing has been cancelled
                        await ConfirmListingStatus(m_ListingId, "CANCELLED");

                        // TODO update to use get stack bundle by stack ID endpoint instead

                        m_SellButton.gameObject.SetActive(true);
                        m_Progress.gameObject.SetActive(false);
                        m_AmountText.text = "Not listed";

                        return;
                    }
                }

                m_Progress.gameObject.SetActive(false);
                m_CancelButton.gameObject.SetActive(true);
                await m_CustomDialog.ShowDialog("Error", "Failed to cancel listing", "OK");
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                m_Progress.gameObject.SetActive(false);
                m_CancelButton.gameObject.SetActive(true);
                await m_CustomDialog.ShowDialog("Error", "Failed to cancel listing", "OK");
            }
        }

        /// <summary>
        ///     Polls the listing status until it transitions to the given status or the operation times out after 1 minute.
        /// </summary>
        private async UniTask ConfirmListingStatus(string listingId, string status)
        {
            Debug.Log($"Confirming listing {listingId} is {status}...");

            var conditionMet = await PollingHelper.PollAsync(
                $"{Config.BASE_URL}/v1/chains/imtbl-zkevm-devnet/orders/listings/{listingId}",
                responseBody =>
                {
                    var listingResponse = JsonUtility.FromJson<ListingResponse>(responseBody);
                    m_ListingId = listingResponse.result.id;
                    return listingResponse.result?.status.name == status;
                });

            if (conditionMet)
                await m_CustomDialog.ShowDialog("Success", $"Listing is {status.ToLower()}.", "OK");
            else
                await m_CustomDialog.ShowDialog("Error", $"Failed to confirm if listing is {status.ToLower()}.", "OK");
        }

        private void OnBackButtonClick()
        {
            UIManager.Instance.GoBack();
        }

        /// <summary>
        ///     Removes all the attribute views
        /// </summary>
        private void ClearAttributes()
        {
            foreach (var attribute in m_Attributes) Destroy(attribute.gameObject);
            m_Attributes.Clear();
        }
    }
}