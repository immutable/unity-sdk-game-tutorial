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
    /// ProtocolData
    /// </summary>
    [DataContract(Name = "ProtocolData")]
    public partial class ProtocolData
    {
        /// <summary>
        /// Seaport order type. Orders containing ERC721 tokens will need to pass in the order type as FULL_RESTRICTED while orders with ERC1155 tokens will need to pass in the order_type as PARTIAL_RESTRICTED
        /// </summary>
        /// <value>Seaport order type. Orders containing ERC721 tokens will need to pass in the order type as FULL_RESTRICTED while orders with ERC1155 tokens will need to pass in the order_type as PARTIAL_RESTRICTED</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrderTypeEnum
        {
            /// <summary>
            /// Enum FULLRESTRICTED for value: FULL_RESTRICTED
            /// </summary>
            [EnumMember(Value = "FULL_RESTRICTED")]
            FULLRESTRICTED = 1,

            /// <summary>
            /// Enum PARTIALRESTRICTED for value: PARTIAL_RESTRICTED
            /// </summary>
            [EnumMember(Value = "PARTIAL_RESTRICTED")]
            PARTIALRESTRICTED = 2
        }


        /// <summary>
        /// Seaport order type. Orders containing ERC721 tokens will need to pass in the order type as FULL_RESTRICTED while orders with ERC1155 tokens will need to pass in the order_type as PARTIAL_RESTRICTED
        /// </summary>
        /// <value>Seaport order type. Orders containing ERC721 tokens will need to pass in the order type as FULL_RESTRICTED while orders with ERC1155 tokens will need to pass in the order_type as PARTIAL_RESTRICTED</value>
        /// <example>FULL_RESTRICTED</example>
        [DataMember(Name = "order_type", IsRequired = true, EmitDefaultValue = true)]
        public OrderTypeEnum OrderType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProtocolData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolData" /> class.
        /// </summary>
        /// <param name="orderType">Seaport order type. Orders containing ERC721 tokens will need to pass in the order type as FULL_RESTRICTED while orders with ERC1155 tokens will need to pass in the order_type as PARTIAL_RESTRICTED (required).</param>
        /// <param name="counter">big.Int or uint256 string for order counter (required).</param>
        /// <param name="zoneAddress">Immutable zone address (required).</param>
        /// <param name="seaportAddress">Immutable Seaport contract address (required).</param>
        /// <param name="seaportVersion">Immutable Seaport contract version (required).</param>
        public ProtocolData(OrderTypeEnum orderType = default(OrderTypeEnum), string counter = default(string), string zoneAddress = default(string), string seaportAddress = default(string), string seaportVersion = default(string))
        {
            this.OrderType = orderType;
            // to ensure "counter" is required (not null)
            if (counter == null)
            {
                throw new ArgumentNullException("counter is a required property for ProtocolData and cannot be null");
            }
            this.Counter = counter;
            // to ensure "zoneAddress" is required (not null)
            if (zoneAddress == null)
            {
                throw new ArgumentNullException("zoneAddress is a required property for ProtocolData and cannot be null");
            }
            this.ZoneAddress = zoneAddress;
            // to ensure "seaportAddress" is required (not null)
            if (seaportAddress == null)
            {
                throw new ArgumentNullException("seaportAddress is a required property for ProtocolData and cannot be null");
            }
            this.SeaportAddress = seaportAddress;
            // to ensure "seaportVersion" is required (not null)
            if (seaportVersion == null)
            {
                throw new ArgumentNullException("seaportVersion is a required property for ProtocolData and cannot be null");
            }
            this.SeaportVersion = seaportVersion;
        }

        /// <summary>
        /// big.Int or uint256 string for order counter
        /// </summary>
        /// <value>big.Int or uint256 string for order counter</value>
        /// <example>92315562</example>
        [DataMember(Name = "counter", IsRequired = true, EmitDefaultValue = true)]
        public string Counter { get; set; }

        /// <summary>
        /// Immutable zone address
        /// </summary>
        /// <value>Immutable zone address</value>
        /// <example>0x12</example>
        [DataMember(Name = "zone_address", IsRequired = true, EmitDefaultValue = true)]
        public string ZoneAddress { get; set; }

        /// <summary>
        /// Immutable Seaport contract address
        /// </summary>
        /// <value>Immutable Seaport contract address</value>
        /// <example>0x12</example>
        [DataMember(Name = "seaport_address", IsRequired = true, EmitDefaultValue = true)]
        public string SeaportAddress { get; set; }

        /// <summary>
        /// Immutable Seaport contract version
        /// </summary>
        /// <value>Immutable Seaport contract version</value>
        /// <example>1.5</example>
        [DataMember(Name = "seaport_version", IsRequired = true, EmitDefaultValue = true)]
        public string SeaportVersion { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ProtocolData {\n");
            sb.Append("  OrderType: ").Append(OrderType).Append("\n");
            sb.Append("  Counter: ").Append(Counter).Append("\n");
            sb.Append("  ZoneAddress: ").Append(ZoneAddress).Append("\n");
            sb.Append("  SeaportAddress: ").Append(SeaportAddress).Append("\n");
            sb.Append("  SeaportVersion: ").Append(SeaportVersion).Append("\n");
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
