using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;
using Immutable.Passport;
using TMPro;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using Immutable.Passport.Model;
using Immutable.Search.Model;

namespace HyperCasual.Runner
{
    /// <summary>
    /// Represents an order list item in the marketplace.
    /// </summary>
    public class OrderListObject : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_NameText;
        [SerializeField] private TextMeshProUGUI m_AmountText;
        [SerializeField] private ImageUrlObject m_Image;

        private StackBundle m_Order;

        /// <summary>
        /// Initialises the order list item with the given order data.
        /// </summary>
        /// <param name="order">The order data to display.</param>
        public async void Initialise(StackBundle order)
        {
            m_Order = order;
            UpdateData();
        }

        /// <summary>
        /// Updates the UI elements with the order data.
        /// </summary>
        private async void UpdateData()
        {
            if (m_Order.Listings.Count > 0)
            {
                string amount = m_Order.Listings[0].PriceDetails.Amount.Value;
                decimal quantity = (decimal)BigInteger.Parse(amount) / (decimal)BigInteger.Pow(10, 18);
                m_AmountText.text = $"{quantity} IMR";
            }

            // Get and display asset details
            m_NameText.text = m_Order.Stack.Name;
            m_Image.LoadUrl(m_Order.Stack.Image);
        }

        public async void OnEnable()
        {
            bool isOnSale = await IsListed();
            if (isOnSale)
            {
                UpdateData();
            }
            else
            {
                m_AmountText.text = "Not listed";
            }
        }

        /// <summary>
        /// Checks if the asset is listed for sale.
        /// </summary>
        private async UniTask<bool> IsListed()
        {
            try
            {
                using var client = new HttpClient();
                string url = $"https://api.sandbox.immutable.com/v1/chains/imtbl-zkevm-testnet/orders/listings/{m_Order.Listings[0].ListingId}";

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ListingResponse listingResponse = JsonUtility.FromJson<ListingResponse>(responseBody);

                    // Check if the listing exists
                    return listingResponse.result?.status.name == "ACTIVE";
                }
            }
            catch (Exception ex)
            {
                Debug.Log($"Failed to check sale status: {ex.Message}");
            }

            return false;
        }
    }
}
