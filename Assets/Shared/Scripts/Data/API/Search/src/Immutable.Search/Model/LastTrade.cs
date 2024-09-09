/*
 * Indexer Search API
 *
 * This API implements endpoints to power data driven marketplace and game experiences
 *
 * The version of the OpenAPI document: 1.0
 * Contact: helpmebuild@immutable.com
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
using OpenAPIDateConverter = Immutable.Search.Client.OpenAPIDateConverter;

namespace Immutable.Search.Model
{
    /// <summary>
    /// Last trade
    /// </summary>
    [DataContract(Name = "LastTrade")]
    public partial class LastTrade
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LastTrade" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LastTrade() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LastTrade" /> class.
        /// </summary>
        /// <param name="tradeId">Trade ID (required).</param>
        /// <param name="tokenId">Token id of the traded asset (uint256 as string) (required).</param>
        /// <param name="priceDetails">Price details, list of payments involved in this trade (required).</param>
        /// <param name="amount">Amount of the trade (uint256 as string) (required).</param>
        /// <param name="createdAt">When the trade was created (required).</param>
        public LastTrade(Guid tradeId = default(Guid), string tokenId = default(string), List<PriceDetails> priceDetails = default(List<PriceDetails>), string amount = default(string), DateTime createdAt = default(DateTime))
        {
            this.TradeId = tradeId;
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for LastTrade and cannot be null");
            }
            this.TokenId = tokenId;
            // to ensure "priceDetails" is required (not null)
            if (priceDetails == null)
            {
                throw new ArgumentNullException("priceDetails is a required property for LastTrade and cannot be null");
            }
            this.PriceDetails = priceDetails;
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for LastTrade and cannot be null");
            }
            this.Amount = amount;
            this.CreatedAt = createdAt;
        }

        /// <summary>
        /// Trade ID
        /// </summary>
        /// <value>Trade ID</value>
        /// <example>4e28df8d-f65c-4c11-ba04-6a9dd47b179b</example>
        [DataMember(Name = "trade_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid TradeId { get; set; }

        /// <summary>
        /// Token id of the traded asset (uint256 as string)
        /// </summary>
        /// <value>Token id of the traded asset (uint256 as string)</value>
        /// <example>1</example>
        [DataMember(Name = "token_id", IsRequired = true, EmitDefaultValue = true)]
        public string TokenId { get; set; }

        /// <summary>
        /// Price details, list of payments involved in this trade
        /// </summary>
        /// <value>Price details, list of payments involved in this trade</value>
        [DataMember(Name = "price_details", IsRequired = true, EmitDefaultValue = true)]
        public List<PriceDetails> PriceDetails { get; set; }

        /// <summary>
        /// Amount of the trade (uint256 as string)
        /// </summary>
        /// <value>Amount of the trade (uint256 as string)</value>
        /// <example>1</example>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public string Amount { get; set; }

        /// <summary>
        /// When the trade was created
        /// </summary>
        /// <value>When the trade was created</value>
        /// <example>2022-08-16T17:43:26.991388Z</example>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LastTrade {\n");
            sb.Append("  TradeId: ").Append(TradeId).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  PriceDetails: ").Append(PriceDetails).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
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
