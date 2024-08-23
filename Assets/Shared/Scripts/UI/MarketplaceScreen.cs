using System;
using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using HyperCasual.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Immutable.Passport;
using Cysharp.Threading.Tasks;
using System.Net.Http;
using TMPro;

namespace HyperCasual.Runner
{
    /// <summary>
    /// The marketplace view which displays currently listed skins.
    /// </summary>
    public class MarketplaceScreen : View
    {
        [SerializeField] private HyperCasualButton m_BackButton;
        [SerializeField] private AbstractGameEvent m_BackEvent;
        [SerializeField] private BalanceObject m_Balance;
        [SerializeField] private TMP_Dropdown m_ColoursDropdown;
        [SerializeField] private TMP_Dropdown m_SpeedDropdown;
        [SerializeField] private OrderListObject m_OrderObj = null;
        [SerializeField] private Transform m_ListParent = null;
        [SerializeField] private InfiniteScrollView m_ScrollView;
        private List<OrderModel> m_Orders = new List<OrderModel>();

        // Pagination
        private bool m_IsLoadingMore = false;
        private PageModel m_Page;

        /// <summary>
        /// Sets up the marketplace list and fetches active orers.
        /// </summary>
        private async void OnEnable()
        {
            // Hide order template item
            m_OrderObj.gameObject.SetActive(false);

            // Add listener to back button
            m_BackButton.RemoveListener(OnBackButtonClick);
            m_BackButton.AddListener(OnBackButtonClick);

            if (Passport.Instance != null)
            {
                // Setup infinite scroll view and load orders
                m_ScrollView.OnCreateItemView += OnCreateItemView;
                LoadOrders();

                // Setup filters
                SetupFilters();

                // Gets the player's balance
                m_Balance.UpdateBalance();
            }
        }

        /// <summary>
        /// Configures the dropdown filters for colours and speeds.
        /// </summary>
        private void SetupFilters()
        {
            m_ColoursDropdown.ClearOptions();
            var colours = new List<string> { "All", "Tropical Indigo", "Cyclamen", "Robin Egg Blue", "Mint", "Mindaro", "Amaranth Pink" };
            m_ColoursDropdown.AddOptions(colours);
            m_ColoursDropdown.value = 0; // Default to "All"

            m_SpeedDropdown.ClearOptions();
            var speeds = new List<string> { "All", "Slow", "Medium", "Fast" };
            m_SpeedDropdown.AddOptions(speeds);
            m_SpeedDropdown.value = 0; // Default to "All"
        }

        /// <summary>
        /// Configures the order list item view
        /// </summary>
        private void OnCreateItemView(int index, GameObject item)
        {
            if (index < m_Orders.Count)
            {
                OrderModel order = m_Orders[index];

                // Initialise the view with order
                var itemComponent = item.GetComponent<OrderListObject>();
                itemComponent.Initialise(order);
                // Set up click listener
                var clickable = item.GetComponent<ClickableView>();
                if (clickable != null)
                {
                    clickable.ClearAllSubscribers();
                    clickable.OnClick += () =>
                    {
                        OrderDetailsView view = UIManager.Instance.GetView<OrderDetailsView>();
                        UIManager.Instance.Show(view, true);
                        view.Initialise(order);
                    };
                }
            }

            // Load more orders if nearing the end of the list
            if (index >= m_Orders.Count - 5 && !m_IsLoadingMore)
            {
                LoadOrders();
            }
        }

        /// <summary>
        /// Loads orders and adds them to the scroll view.
        /// </summary>
        private async void LoadOrders()
        {
            if (m_IsLoadingMore)
            {
                return;
            }

            m_IsLoadingMore = true;

            List<OrderModel> orders = await GetOrders();
            if (orders != null && orders.Count > 0)
            {
                m_Orders.AddRange(orders);
                m_ScrollView.TotalItemCount = m_Orders.Count;
            }

            m_IsLoadingMore = false;
        }

        /// <summary>
        /// Retrieves the players's wallet address.
        /// </summary>
        private async UniTask<string> GetWalletAddress()
        {
            List<string> accounts = await Passport.Instance.ZkEvmRequestAccounts();
            return accounts.Count > 0 ? accounts[0] : string.Empty; // Return the first wallet address
        }

        /// <summary>
        /// Parses the JSON response body to extract orders.
        /// Updates the pagination info from the response.
        /// </summary>
        private List<OrderModel> ParseOrdersResponse(string responseBody)
        {
            if (string.IsNullOrEmpty(responseBody))
            {
                return new List<OrderModel>();
            }

            OrdersResponse response = JsonUtility.FromJson<OrdersResponse>(responseBody);
            if (response == null)
            {
                return new List<OrderModel>();
            }

            // Update pagination information
            m_Page = response.page;

            return response.result ?? new List<OrderModel>();
        }

        /// <summary>
        /// Fetches active orders.
        /// </summary>
        private async UniTask<List<OrderModel>> GetOrders()
        {
            Debug.Log("Fetching active orders...");

            List<OrderModel> tokens = new List<OrderModel>();

            try
            {
                string address = await GetWalletAddress();

                if (string.IsNullOrEmpty(address))
                {
                    Debug.LogError("Could not get player's wallet");
                    return tokens;
                }

                string url = $"https://api.sandbox.immutable.com/v1/chains/imtbl-zkevm-testnet/orders/listings?sell_item_contract_address={Contract.SKIN}&page_size=5&status=ACTIVE";

                // Pagination
                if (m_Page?.next_cursor != null)
                {
                    url += $"&page_cursor={m_Page.next_cursor}";
                }
                else if (m_Page != null && m_Page.next_cursor != null)
                {
                    Debug.Log("No more orders to load");
                    return tokens;
                }

                using var client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Debug.Log($"Orders response: {responseBody}");

                    tokens = ParseOrdersResponse(responseBody);
                }
                else
                {
                    // TODO use dialogs
                    Debug.Log($"Failed to fetch orders");
                }
            }
            catch (Exception ex)
            {
                Debug.Log($"Failed to fetch orders: {ex.Message}");
            }

            return tokens;
        }

        /// <summary>
        /// Cleans up views and handles the back button click
        /// </summary>
        private void OnBackButtonClick()
        {
            // Clear the order list
            m_Orders.Clear();

            // Reset pagination information
            m_Page = null;

            // Reset the InfiniteScrollView
            m_ScrollView.TotalItemCount = 0;
            m_ScrollView.Clear(); // Resets the scroll view

            // Trigger back button event
            m_BackEvent.Raise();
        }
    }
}
