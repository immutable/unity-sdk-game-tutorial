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
    /// SalePayment
    /// </summary>
    [DataContract(Name = "SalePayment")]
    public partial class SalePayment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalePayment" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SalePayment() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SalePayment" /> class.
        /// </summary>
        /// <param name="token">token (required).</param>
        /// <param name="priceExcludingFees">The base price of the sale not including any fees (required).</param>
        /// <param name="priceIncludingFees">The total price of the sale. Includes the sum of all fees (required).</param>
        /// <param name="fees">The fees associated with this sale (required).</param>
        public SalePayment(SalePaymentToken token = default(SalePaymentToken), string priceExcludingFees = default(string), string priceIncludingFees = default(string), List<SaleFee> fees = default(List<SaleFee>))
        {
            // to ensure "token" is required (not null)
            if (token == null)
            {
                throw new ArgumentNullException("token is a required property for SalePayment and cannot be null");
            }
            this.Token = token;
            // to ensure "priceExcludingFees" is required (not null)
            if (priceExcludingFees == null)
            {
                throw new ArgumentNullException("priceExcludingFees is a required property for SalePayment and cannot be null");
            }
            this.PriceExcludingFees = priceExcludingFees;
            // to ensure "priceIncludingFees" is required (not null)
            if (priceIncludingFees == null)
            {
                throw new ArgumentNullException("priceIncludingFees is a required property for SalePayment and cannot be null");
            }
            this.PriceIncludingFees = priceIncludingFees;
            // to ensure "fees" is required (not null)
            if (fees == null)
            {
                throw new ArgumentNullException("fees is a required property for SalePayment and cannot be null");
            }
            this.Fees = fees;
        }

        /// <summary>
        /// Gets or Sets Token
        /// </summary>
        [DataMember(Name = "token", IsRequired = true, EmitDefaultValue = true)]
        public SalePaymentToken Token { get; set; }

        /// <summary>
        /// The base price of the sale not including any fees
        /// </summary>
        /// <value>The base price of the sale not including any fees</value>
        /// <example>180</example>
        [DataMember(Name = "price_excluding_fees", IsRequired = true, EmitDefaultValue = true)]
        public string PriceExcludingFees { get; set; }

        /// <summary>
        /// The total price of the sale. Includes the sum of all fees
        /// </summary>
        /// <value>The total price of the sale. Includes the sum of all fees</value>
        /// <example>200</example>
        [DataMember(Name = "price_including_fees", IsRequired = true, EmitDefaultValue = true)]
        public string PriceIncludingFees { get; set; }

        /// <summary>
        /// The fees associated with this sale
        /// </summary>
        /// <value>The fees associated with this sale</value>
        /// <example>[{&quot;address&quot;:&quot;0xB0F3749458169B7Ad51B5503CC3649DE55c2D0D2&quot;,&quot;amount&quot;:&quot;20&quot;,&quot;type&quot;:&quot;ROYALTY&quot;}]</example>
        [DataMember(Name = "fees", IsRequired = true, EmitDefaultValue = true)]
        public List<SaleFee> Fees { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SalePayment {\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
            sb.Append("  PriceExcludingFees: ").Append(PriceExcludingFees).Append("\n");
            sb.Append("  PriceIncludingFees: ").Append(PriceIncludingFees).Append("\n");
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
