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
    /// V1TsSdkV1OrderbookCancelOrdersPost200ResponseResultFailedCancellationsInner
    /// </summary>
    [DataContract(Name = "_v1_ts_sdk_v1_orderbook_cancelOrders_post_200_response_result_failed_cancellations_inner")]
    public partial class V1TsSdkV1OrderbookCancelOrdersPost200ResponseResultFailedCancellationsInner
    {
        /// <summary>
        /// Reason code indicating why the order failed to be cancelled
        /// </summary>
        /// <value>Reason code indicating why the order failed to be cancelled</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ReasonCodeEnum
        {
            /// <summary>
            /// Enum FILLED for value: FILLED
            /// </summary>
            [EnumMember(Value = "FILLED")]
            FILLED = 1
        }


        /// <summary>
        /// Reason code indicating why the order failed to be cancelled
        /// </summary>
        /// <value>Reason code indicating why the order failed to be cancelled</value>
        [DataMember(Name = "reason_code", EmitDefaultValue = false)]
        public ReasonCodeEnum? ReasonCode { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="V1TsSdkV1OrderbookCancelOrdersPost200ResponseResultFailedCancellationsInner" /> class.
        /// </summary>
        /// <param name="order">ID of the order which failed to be cancelled.</param>
        /// <param name="reasonCode">Reason code indicating why the order failed to be cancelled.</param>
        public V1TsSdkV1OrderbookCancelOrdersPost200ResponseResultFailedCancellationsInner(string order = default(string), ReasonCodeEnum? reasonCode = default(ReasonCodeEnum?))
        {
            this.Order = order;
            this.ReasonCode = reasonCode;
        }

        /// <summary>
        /// ID of the order which failed to be cancelled
        /// </summary>
        /// <value>ID of the order which failed to be cancelled</value>
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public string Order { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class V1TsSdkV1OrderbookCancelOrdersPost200ResponseResultFailedCancellationsInner {\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  ReasonCode: ").Append(ReasonCode).Append("\n");
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
