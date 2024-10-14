/*
 * Immutable zkEVM API
 *
 * Immutable Multi Rollup API
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: support@immutable.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = Immutable.Api.Client.OpenAPIDateConverter;

namespace Immutable.Api.Model
{
    /// <summary>
    /// Trade
    /// </summary>
    [DataContract(Name = "Trade")]
    public partial class Trade
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trade" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Trade() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Trade" /> class.
        /// </summary>
        /// <param name="buy">Buy items are transferred from the taker to the maker. (required).</param>
        /// <param name="buyerAddress">Deprecated. Use maker and taker addresses instead of buyer and seller addresses. (required).</param>
        /// <param name="buyerFees">Deprecated. Use fees instead. The taker always pays the fees. (required).</param>
        /// <param name="fees">fees (required).</param>
        /// <param name="chain">chain (required).</param>
        /// <param name="orderId">orderId (required).</param>
        /// <param name="blockchainMetadata">blockchainMetadata (required).</param>
        /// <param name="indexedAt">Time the on-chain trade event is indexed by the order book system (required).</param>
        /// <param name="id">Global Trade identifier (required).</param>
        /// <param name="sell">Sell items are transferred from the maker to the taker. (required).</param>
        /// <param name="sellerAddress">Deprecated. Use maker and taker addresses instead of buyer and seller addresses. (required).</param>
        /// <param name="makerAddress">makerAddress (required).</param>
        /// <param name="takerAddress">takerAddress (required).</param>
        public Trade(List<Item> buy = default(List<Item>), string buyerAddress = default(string), List<Fee> buyerFees = default(List<Fee>), List<Fee> fees = default(List<Fee>), Chain chain = default(Chain), string orderId = default(string), TradeBlockchainMetadata blockchainMetadata = default(TradeBlockchainMetadata), DateTime indexedAt = default(DateTime), string id = default(string), List<Item> sell = default(List<Item>), string sellerAddress = default(string), string makerAddress = default(string), string takerAddress = default(string))
        {
            // to ensure "buy" is required (not null)
            if (buy == null)
            {
                throw new ArgumentNullException("buy is a required property for Trade and cannot be null");
            }
            this.Buy = buy;
            // to ensure "buyerAddress" is required (not null)
            if (buyerAddress == null)
            {
                throw new ArgumentNullException("buyerAddress is a required property for Trade and cannot be null");
            }
            this.BuyerAddress = buyerAddress;
            // to ensure "buyerFees" is required (not null)
            if (buyerFees == null)
            {
                throw new ArgumentNullException("buyerFees is a required property for Trade and cannot be null");
            }
            this.BuyerFees = buyerFees;
            // to ensure "fees" is required (not null)
            if (fees == null)
            {
                throw new ArgumentNullException("fees is a required property for Trade and cannot be null");
            }
            this.Fees = fees;
            // to ensure "chain" is required (not null)
            if (chain == null)
            {
                throw new ArgumentNullException("chain is a required property for Trade and cannot be null");
            }
            this.Chain = chain;
            // to ensure "orderId" is required (not null)
            if (orderId == null)
            {
                throw new ArgumentNullException("orderId is a required property for Trade and cannot be null");
            }
            this.OrderId = orderId;
            // to ensure "blockchainMetadata" is required (not null)
            if (blockchainMetadata == null)
            {
                throw new ArgumentNullException("blockchainMetadata is a required property for Trade and cannot be null");
            }
            this.BlockchainMetadata = blockchainMetadata;
            this.IndexedAt = indexedAt;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for Trade and cannot be null");
            }
            this.Id = id;
            // to ensure "sell" is required (not null)
            if (sell == null)
            {
                throw new ArgumentNullException("sell is a required property for Trade and cannot be null");
            }
            this.Sell = sell;
            // to ensure "sellerAddress" is required (not null)
            if (sellerAddress == null)
            {
                throw new ArgumentNullException("sellerAddress is a required property for Trade and cannot be null");
            }
            this.SellerAddress = sellerAddress;
            // to ensure "makerAddress" is required (not null)
            if (makerAddress == null)
            {
                throw new ArgumentNullException("makerAddress is a required property for Trade and cannot be null");
            }
            this.MakerAddress = makerAddress;
            // to ensure "takerAddress" is required (not null)
            if (takerAddress == null)
            {
                throw new ArgumentNullException("takerAddress is a required property for Trade and cannot be null");
            }
            this.TakerAddress = takerAddress;
        }

        /// <summary>
        /// Buy items are transferred from the taker to the maker.
        /// </summary>
        /// <value>Buy items are transferred from the taker to the maker.</value>
        /// <example>[{&quot;type&quot;:&quot;NATIVE&quot;,&quot;amount&quot;:&quot;9750000000000000000&quot;,&quot;contract_address&quot;:&quot;0x0165878A594ca255338adfa4d48449f69242Eb8F&quot;}]</example>
        [DataMember(Name = "buy", IsRequired = true, EmitDefaultValue = true)]
        public List<Item> Buy { get; set; }

        /// <summary>
        /// Deprecated. Use maker and taker addresses instead of buyer and seller addresses.
        /// </summary>
        /// <value>Deprecated. Use maker and taker addresses instead of buyer and seller addresses.</value>
        /// <example>0xFC99a706C0D05B8C71E1fAAC91b3E1343aC34D40</example>
        [DataMember(Name = "buyer_address", IsRequired = true, EmitDefaultValue = true)]
        public string BuyerAddress { get; set; }

        /// <summary>
        /// Deprecated. Use fees instead. The taker always pays the fees.
        /// </summary>
        /// <value>Deprecated. Use fees instead. The taker always pays the fees.</value>
        /// <example>[]</example>
        [DataMember(Name = "buyer_fees", IsRequired = true, EmitDefaultValue = true)]
        public List<Fee> BuyerFees { get; set; }

        /// <summary>
        /// Gets or Sets Fees
        /// </summary>
        /// <example>[]</example>
        [DataMember(Name = "fees", IsRequired = true, EmitDefaultValue = true)]
        public List<Fee> Fees { get; set; }

        /// <summary>
        /// Gets or Sets Chain
        /// </summary>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public Chain Chain { get; set; }

        /// <summary>
        /// Gets or Sets OrderId
        /// </summary>
        /// <example>7df3e99e-f7b3-459c-bef6-ffb66a18bb59</example>
        [DataMember(Name = "order_id", IsRequired = true, EmitDefaultValue = true)]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or Sets BlockchainMetadata
        /// </summary>
        [DataMember(Name = "blockchain_metadata", IsRequired = true, EmitDefaultValue = true)]
        public TradeBlockchainMetadata BlockchainMetadata { get; set; }

        /// <summary>
        /// Time the on-chain trade event is indexed by the order book system
        /// </summary>
        /// <value>Time the on-chain trade event is indexed by the order book system</value>
        /// <example>2022-03-07T07:20:50.520Z</example>
        [DataMember(Name = "indexed_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime IndexedAt { get; set; }

        /// <summary>
        /// Global Trade identifier
        /// </summary>
        /// <value>Global Trade identifier</value>
        /// <example>018792C9-4AD7-8EC4-4038-9E05C598534A</example>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Sell items are transferred from the maker to the taker.
        /// </summary>
        /// <value>Sell items are transferred from the maker to the taker.</value>
        /// <example>[{&quot;type&quot;:&quot;ERC721&quot;,&quot;contract_address&quot;:&quot;0x692edAd005237c7E737bB2c0F3D8ccCc10D3479E&quot;,&quot;token_id&quot;:&quot;1&quot;}]</example>
        [DataMember(Name = "sell", IsRequired = true, EmitDefaultValue = true)]
        public List<Item> Sell { get; set; }

        /// <summary>
        /// Deprecated. Use maker and taker addresses instead of buyer and seller addresses.
        /// </summary>
        /// <value>Deprecated. Use maker and taker addresses instead of buyer and seller addresses.</value>
        /// <example>0x002b9B1cbf464782Df5d48870358FA6c09f1b19D</example>
        [DataMember(Name = "seller_address", IsRequired = true, EmitDefaultValue = true)]
        public string SellerAddress { get; set; }

        /// <summary>
        /// Gets or Sets MakerAddress
        /// </summary>
        /// <example>0x002b9B1cbf464782Df5d48870358FA6c09f1b19D</example>
        [DataMember(Name = "maker_address", IsRequired = true, EmitDefaultValue = true)]
        public string MakerAddress { get; set; }

        /// <summary>
        /// Gets or Sets TakerAddress
        /// </summary>
        /// <example>0xFC99a706C0D05B8C71E1fAAC91b3E1343aC34D40</example>
        [DataMember(Name = "taker_address", IsRequired = true, EmitDefaultValue = true)]
        public string TakerAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Trade {\n");
            sb.Append("  Buy: ").Append(Buy).Append("\n");
            sb.Append("  BuyerAddress: ").Append(BuyerAddress).Append("\n");
            sb.Append("  BuyerFees: ").Append(BuyerFees).Append("\n");
            sb.Append("  Fees: ").Append(Fees).Append("\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  BlockchainMetadata: ").Append(BlockchainMetadata).Append("\n");
            sb.Append("  IndexedAt: ").Append(IndexedAt).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Sell: ").Append(Sell).Append("\n");
            sb.Append("  SellerAddress: ").Append(SellerAddress).Append("\n");
            sb.Append("  MakerAddress: ").Append(MakerAddress).Append("\n");
            sb.Append("  TakerAddress: ").Append(TakerAddress).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }

}
