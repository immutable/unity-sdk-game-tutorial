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
    /// Linked wallet
    /// </summary>
    [DataContract(Name = "Wallet")]
    public partial class Wallet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Wallet" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Wallet() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Wallet" /> class.
        /// </summary>
        /// <param name="address">Ethereum address (required).</param>
        /// <param name="type">Wallet type (required).</param>
        /// <param name="createdAt">Created at (required).</param>
        /// <param name="updatedAt">Created at (required).</param>
        /// <param name="name">Name.</param>
        /// <param name="clientName">Name of client that linked the wallet (required).</param>
        public Wallet(string address = default(string), string type = default(string), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime), string name = default(string), string clientName = default(string))
        {
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for Wallet and cannot be null");
            }
            this.Address = address;
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for Wallet and cannot be null");
            }
            this.Type = type;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            // to ensure "clientName" is required (not null)
            if (clientName == null)
            {
                throw new ArgumentNullException("clientName is a required property for Wallet and cannot be null");
            }
            this.ClientName = clientName;
            this.Name = name;
        }

        /// <summary>
        /// Ethereum address
        /// </summary>
        /// <value>Ethereum address</value>
        /// <example>0xd8da6bf26964af9d7eed9e03e53415d37aa96045</example>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Wallet type
        /// </summary>
        /// <value>Wallet type</value>
        /// <example>MetaMask</example>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public string Type { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        /// <value>Created at</value>
        /// <example>2021-08-31T00:00Z</example>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        /// <value>Created at</value>
        /// <example>2021-08-31T00:00Z</example>
        [DataMember(Name = "updated_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        /// <value>Name</value>
        /// <example>Test</example>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Name of client that linked the wallet
        /// </summary>
        /// <value>Name of client that linked the wallet</value>
        /// <example>Passport Dashboard</example>
        [DataMember(Name = "clientName", IsRequired = true, EmitDefaultValue = true)]
        public string ClientName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Wallet {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ClientName: ").Append(ClientName).Append("\n");
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
