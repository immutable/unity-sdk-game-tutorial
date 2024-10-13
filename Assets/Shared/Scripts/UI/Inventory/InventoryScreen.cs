using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using HyperCasual.Core;
using UnityEngine;
using TMPro;
using Immutable.Api.Client;
using Immutable.Api.Model;
using Immutable.Api.Api;
using UnityEngine.Serialization;

namespace HyperCasual.Runner
{
    /// <summary>
    ///     The inventory view which displays the player's assets (e.g. skins).
    /// </summary>
    public class InventoryScreen : View
    {
        public enum AssetType
        {
            Skin,
            Powerups
        }

        [SerializeField] private HyperCasualButton m_BackButton;
        [SerializeField] private HyperCasualButton m_AddButton;
        [SerializeField] private AbstractGameEvent m_BackEvent;
        [SerializeField] private BalanceObject m_Balance;

        [SerializeField] private TMP_Dropdown m_TypeDropdown;

        [FormerlySerializedAs("m_AssetObj")] [SerializeField] private InventoryListObject mInventoryObj;
        [SerializeField] private InfiniteScrollGridView m_ScrollView;
        [SerializeField] private AddFunds m_AddFunds;

        private StacksApi m_StacksApi;

        private AssetType m_Type = AssetType.Skin;

        private readonly List<NFTBundle> m_Assets = new();

        // Pagination
        private bool m_IsLoadingMore;
        private Page m_Page;
        
        public InventoryScreen()
        {
            var config = new Configuration { BasePath = Config.BASE_URL };
            m_StacksApi = new StacksApi(config);
        }

        /// <summary>
        ///     Sets up the inventory list and fetches the player's assets.
        /// </summary>
        private async void OnEnable()
        {
            // Hide asset template item
            mInventoryObj.gameObject.SetActive(false);

            m_BackButton.RemoveListener(OnBackButtonClick);
            m_BackButton.AddListener(OnBackButtonClick);

            m_AddButton.RemoveListener(OnAddFundsButtonClick);
            m_AddButton.AddListener(OnAddFundsButtonClick);

            // Setup infinite scroll view and load assets
            m_ScrollView.OnCreateItemView += OnCreateItemView;
            if (m_Assets.Count == 0) LoadAssets();

            m_Balance.UpdateBalance();

            SetupFilters();
        }

        /// <summary>
        ///     Configures the dropdown filters
        /// </summary>
        private void SetupFilters()
        {
            var types = Enum.GetNames(typeof(AssetType)).ToList();

            m_TypeDropdown.ClearOptions();
            m_TypeDropdown.AddOptions(types);
            m_TypeDropdown.value = 0;

            m_TypeDropdown.onValueChanged.AddListener(delegate
            {
                Reset();
                int selectedIndex = m_TypeDropdown.value;
                m_Type = (AssetType)Enum.GetValues(typeof(AssetType)).GetValue(selectedIndex);
                LoadAssets();
            });
        }

        /// <summary>
        ///     Configures the asset list item view
        /// </summary>
        private void OnCreateItemView(int index, GameObject item)
        {
            if (index < m_Assets.Count)
            {
                var asset = m_Assets[index];

                // Initialise the view with asset
                var itemComponent = item.GetComponent<InventoryListObject>();
                itemComponent.Initialise(asset);
                // Set up click listener
                var clickable = item.GetComponent<ClickableView>();
                if (clickable != null)
                {
                    clickable.ClearAllSubscribers();
                    clickable.OnClick += () =>
                    {
                        var view = UIManager.Instance.GetView<InventoryAssetDetailsView>();
                        UIManager.Instance.Show(view);
                        view.Initialise(asset);
                    };
                }
            }

            // Load more assets if nearing the end of the list
            if (index >= m_Assets.Count - 8 && !m_IsLoadingMore) LoadAssets();
        }

        /// <summary>
        ///     Loads assets and adds them to the scroll view.
        /// </summary>
        private async void LoadAssets()
        {
            if (m_IsLoadingMore) return;

            m_IsLoadingMore = true;

            var assets = await GetAssets();
            if (assets != null && assets.Count > 0)
            {
                m_Assets.AddRange(assets);
                m_ScrollView.TotalItemCount = m_Assets.Count;
            }

            m_IsLoadingMore = false;
        }

        // Uses mocked stacks endpoint
        private async UniTask<List<NFTBundle>> GetAssets()
        {
            Debug.Log("Fetching assets...");

            var assets = new List<NFTBundle>();

            try
            {
                var nextCursor = m_Page?.NextCursor ?? null;
                if (m_Page != null && string.IsNullOrEmpty(nextCursor))
                {
                    Debug.Log("No more assets to load");
                    return assets;
                }
                
                var contractAddress = m_Type switch
                {
                    AssetType.Skin => Contract.SKIN,
                    AssetType.Powerups => Contract.PACK,
                    _ => Contract.SKIN
                };

                var result = await m_StacksApi.SearchNFTsAsync(
                    chainName: Config.CHAIN_NAME,
                    contractAddress: new List<string> { contractAddress },
                    accountAddress: SaveManager.Instance.WalletAddress,
                    onlyIncludeOwnerListings: true,
                    pageSize: Config.PAGE_SIZE,
                    pageCursor: nextCursor);
                
                m_Page = result.Page;
                return result.Result;
            }
            catch (ApiException e)
            {
                Debug.LogError($"API error: {e.Message} (Status Code: {e.ErrorCode})");
                Debug.LogError(e.StackTrace);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error fetching NFTs: {ex.Message}");
            }

            return assets;
        }

        /// <summary>
        ///     Cleans up views and handles the back button click
        /// </summary>
        private void OnBackButtonClick()
        {
            Reset();

            // Trigger back button event
            m_BackEvent.Raise();
        }

        private void Reset()
        {
            // Reset default contract
            m_Type = AssetType.Skin;

            // Clear the asset list
            m_Assets.Clear();

            // Reset pagination information
            m_Page = null;

            // Reset the InfiniteScrollView
            m_ScrollView.TotalItemCount = 0;
            m_ScrollView.Clear();
        }

        /// <summary>
        ///     handles the add funds button click
        /// </summary>
        private void OnAddFundsButtonClick()
        {
            m_AddFunds.Show();
        }
    }
}