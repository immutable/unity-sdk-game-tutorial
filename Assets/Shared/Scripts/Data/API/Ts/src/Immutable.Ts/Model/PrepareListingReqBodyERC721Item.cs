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
    /// PrepareListingReqBodyERC721Item
    /// </summary>
    [DataContract(Name = "prepareListingReqBodyERC721Item")]
    public partial class PrepareListingReqBodyERC721Item
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum ERC721 for value: ERC721
            /// </summary>
            [EnumMember(Value = "ERC721")]
            ERC721 = 1
        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareListingReqBodyERC721Item" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PrepareListingReqBodyERC721Item() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareListingReqBodyERC721Item" /> class.
        /// </summary>
        /// <param name="contractAddress">contractAddress (required).</param>
        /// <param name="tokenId">tokenId (required).</param>
        /// <param name="type">type (required).</param>
        public PrepareListingReqBodyERC721Item(string contractAddress = default(string), string tokenId = default(string), TypeEnum type = default(TypeEnum))
        {
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for PrepareListingReqBodyERC721Item and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for PrepareListingReqBodyERC721Item and cannot be null");
            }
            this.TokenId = tokenId;
            this.Type = type;
        }

        /// <summary>
        /// Gets or Sets ContractAddress
        /// </summary>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Gets or Sets TokenId
        /// </summary>
        [DataMember(Name = "tokenId", IsRequired = true, EmitDefaultValue = true)]
        public string TokenId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PrepareListingReqBodyERC721Item {\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
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
