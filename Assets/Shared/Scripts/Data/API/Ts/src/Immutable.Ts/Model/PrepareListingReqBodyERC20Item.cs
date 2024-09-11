/*
 * TS SDK API
 *
 * running ts sdk as an api
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: contact@immutable.com
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
using OpenAPIDateConverter = Immutable.Ts.Client.OpenAPIDateConverter;

namespace Immutable.Ts.Model
{
    /// <summary>
    /// PrepareListingReqBodyERC20Item
    /// </summary>
    [DataContract(Name = "prepareListingReqBodyERC20Item")]
    public partial class PrepareListingReqBodyERC20Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareListingReqBodyERC20Item" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PrepareListingReqBodyERC20Item() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareListingReqBodyERC20Item" /> class.
        /// </summary>
        /// <param name="amount">amount (required).</param>
        /// <param name="contractAddress">contractAddress (required).</param>
        /// <param name="type">type (required).</param>
        public PrepareListingReqBodyERC20Item(string amount = default(string), string contractAddress = default(string), string type = default(string))
        {
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for PrepareListingReqBodyERC20Item and cannot be null");
            }
            this.Amount = amount;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for PrepareListingReqBodyERC20Item and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for PrepareListingReqBodyERC20Item and cannot be null");
            }
            this.Type = type;
        }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or Sets ContractAddress
        /// </summary>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public string Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PrepareListingReqBodyERC20Item {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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