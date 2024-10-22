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
    /// ERC721CollectionItem
    /// </summary>
    [DataContract(Name = "ERC721CollectionItem")]
    public partial class ERC721CollectionItem
    {
        /// <summary>
        /// Token type user is offering, which in this case is ERC721
        /// </summary>
        /// <value>Token type user is offering, which in this case is ERC721</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum ERC721COLLECTION for value: ERC721_COLLECTION
            /// </summary>
            [EnumMember(Value = "ERC721_COLLECTION")]
            ERC721COLLECTION = 1
        }


        /// <summary>
        /// Token type user is offering, which in this case is ERC721
        /// </summary>
        /// <value>Token type user is offering, which in this case is ERC721</value>
        /// <example>ERC721_COLLECTION</example>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ERC721CollectionItem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ERC721CollectionItem() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ERC721CollectionItem" /> class.
        /// </summary>
        /// <param name="type">Token type user is offering, which in this case is ERC721 (required).</param>
        /// <param name="contractAddress">Address of ERC721 collection (required).</param>
        /// <param name="amount">A string representing the price at which the user is willing to sell the token. This value is provided in the smallest unit of the token (e.g., wei for Ethereum). (required).</param>
        public ERC721CollectionItem(TypeEnum type = default(TypeEnum), string contractAddress = default(string), string amount = default(string))
        {
            this.Type = type;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for ERC721CollectionItem and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for ERC721CollectionItem and cannot be null");
            }
            this.Amount = amount;
        }

        /// <summary>
        /// Address of ERC721 collection
        /// </summary>
        /// <value>Address of ERC721 collection</value>
        /// <example>0x692edAd005237c7E737bB2c0F3D8ccCc10D3479E</example>
        [DataMember(Name = "contract_address", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// A string representing the price at which the user is willing to sell the token. This value is provided in the smallest unit of the token (e.g., wei for Ethereum).
        /// </summary>
        /// <value>A string representing the price at which the user is willing to sell the token. This value is provided in the smallest unit of the token (e.g., wei for Ethereum).</value>
        /// <example>9750000000000000000</example>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public string Amount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ERC721CollectionItem {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
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