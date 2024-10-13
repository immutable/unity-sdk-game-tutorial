using System.Numerics;
using Immutable.Api.Model;
using TMPro;
using UnityEngine;

namespace HyperCasual.Runner
{
    /// <summary>
    ///     Represents an asset in the player's inventory
    /// </summary>
    public class InventoryListObject : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_NameText;
        [SerializeField] private TextMeshProUGUI m_TokenIdText;
        [SerializeField] private TextMeshProUGUI m_AmountText;
        [SerializeField] private ImageUrlObject m_Image;

        private NFTBundle m_Asset;

        /// <summary>
        ///     Sets up the inventory list and fetches the player's assets.
        /// </summary>
        private void OnEnable()
        {
            UpdateData();
        }

        /// <summary>
        ///     Initialises the asset object with relevant data and updates the UI.
        /// </summary>
        public void Initialise(NFTBundle asset)
        {
            m_Asset = asset;
            UpdateData();
        }

        /// <summary>
        ///     Updates the text fields with asset data.
        /// </summary>
        private async void UpdateData()
        {
            if (m_Asset == null) return;

            m_NameText.text = m_Asset.NftWithStack.ContractType.ToUpper() switch
            {
                "ERC721" => $"{m_Asset.NftWithStack.Name} #{m_Asset.NftWithStack.TokenId}",
                "ERC1155" => $"{m_Asset.NftWithStack.Name} x{m_Asset.NftWithStack.Balance}",
                _ => m_NameText.text
            };

            m_AmountText.gameObject.SetActive(m_Asset.NftWithStack.ContractType.ToUpper() == "ERC721");
            m_AmountText.text = "-";

            Listing? listing = m_Asset.Listings.Count > 0 ? m_Asset.Listings[0] : null;
            if (listing != null)
            {
                var amount = listing.PriceDetails.Amount.Value;
                var quantity = (decimal)BigInteger.Parse(amount) / (decimal)BigInteger.Pow(10, 18);
                m_AmountText.text = $"{quantity} IMR";
            }
            else
            {
                m_AmountText.text = "Not listed";
            }

#pragma warning disable CS4014
            m_Image.LoadUrl(m_Asset.NftWithStack.Image);
#pragma warning restore CS4014
        }
    }
}