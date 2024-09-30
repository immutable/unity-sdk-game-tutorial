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
    /// Price details
    /// </summary>
    [DataContract(Name = "PriceDetails")]
    public partial class PriceDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PriceDetails() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceDetails" /> class.
        /// </summary>
        /// <param name="token">token (required).</param>
        /// <param name="amount">amount (required).</param>
        /// <param name="feeInclusiveAmount">feeInclusiveAmount (required).</param>
        /// <param name="fees">fees (required).</param>
        public PriceDetails(PriceDetailsToken token = default(PriceDetailsToken), PaymentAmount amount = default(PaymentAmount), PaymentAmount feeInclusiveAmount = default(PaymentAmount), List<Fee> fees = default(List<Fee>))
        {
            // to ensure "token" is required (not null)
            if (token == null)
            {
                throw new ArgumentNullException("token is a required property for PriceDetails and cannot be null");
            }
            this.Token = token;
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for PriceDetails and cannot be null");
            }
            this.Amount = amount;
            // to ensure "feeInclusiveAmount" is required (not null)
            if (feeInclusiveAmount == null)
            {
                throw new ArgumentNullException("feeInclusiveAmount is a required property for PriceDetails and cannot be null");
            }
            this.FeeInclusiveAmount = feeInclusiveAmount;
            // to ensure "fees" is required (not null)
            if (fees == null)
            {
                throw new ArgumentNullException("fees is a required property for PriceDetails and cannot be null");
            }
            this.Fees = fees;
        }

        /// <summary>
        /// Gets or Sets Token
        /// </summary>
        [DataMember(Name = "token", IsRequired = true, EmitDefaultValue = true)]
        public PriceDetailsToken Token { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public PaymentAmount Amount { get; set; }

        /// <summary>
        /// Gets or Sets FeeInclusiveAmount
        /// </summary>
        [DataMember(Name = "fee_inclusive_amount", IsRequired = true, EmitDefaultValue = true)]
        public PaymentAmount FeeInclusiveAmount { get; set; }

        /// <summary>
        /// Gets or Sets Fees
        /// </summary>
        /// <example>[{&quot;type&quot;:&quot;TAKER_ECOSYSTEM&quot;,&quot;recipient_address&quot;:1390849295786071768276380950238675083608645509683,&quot;amount&quot;:&quot;1000000000000000000&quot;}]</example>
        [DataMember(Name = "fees", IsRequired = true, EmitDefaultValue = true)]
        public List<Fee> Fees { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PriceDetails {\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  FeeInclusiveAmount: ").Append(FeeInclusiveAmount).Append("\n");
            sb.Append("  Fees: ").Append(Fees).Append("\n");
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