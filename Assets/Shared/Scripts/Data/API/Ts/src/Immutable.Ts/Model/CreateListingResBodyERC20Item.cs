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
    /// CreateListingResBodyERC20Item
    /// </summary>
    [DataContract(Name = "createListingResBodyERC20Item")]
    public partial class CreateListingResBodyERC20Item
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum ERC20 for value: ERC20
            /// </summary>
            [EnumMember(Value = "ERC20")]
            ERC20 = 1
        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateListingResBodyERC20Item" /> class.
        /// </summary>
        /// <param name="amount">amount.</param>
        /// <param name="contractAddress">contractAddress.</param>
        /// <param name="type">type.</param>
        public CreateListingResBodyERC20Item(string amount = default(string), string contractAddress = default(string), TypeEnum? type = default(TypeEnum?))
        {
            this.Amount = amount;
            this.ContractAddress = contractAddress;
            this.Type = type;
        }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or Sets ContractAddress
        /// </summary>
        [DataMember(Name = "contractAddress", EmitDefaultValue = false)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateListingResBodyERC20Item {\n");
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
