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
    /// APIError401
    /// </summary>
    [DataContract(Name = "APIError401")]
    public partial class APIError401
    {
        /// <summary>
        /// Error Code
        /// </summary>
        /// <value>Error Code</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CodeEnum
        {
            /// <summary>
            /// Enum UNAUTHORISEDREQUEST for value: UNAUTHORISED_REQUEST
            /// </summary>
            [EnumMember(Value = "UNAUTHORISED_REQUEST")]
            UNAUTHORISEDREQUEST = 1
        }


        /// <summary>
        /// Error Code
        /// </summary>
        /// <value>Error Code</value>
        /// <example>UNAUTHORISED_REQUEST</example>
        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = true)]
        public CodeEnum Code { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="APIError401" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected APIError401() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="APIError401" /> class.
        /// </summary>
        /// <param name="message">Error Message (required).</param>
        /// <param name="link">Link to IMX documentation that can help resolve this error (required).</param>
        /// <param name="traceId">Trace ID of the initial request (required).</param>
        /// <param name="code">Error Code (required).</param>
        /// <param name="details">Additional details to help resolve the error (required).</param>
        public APIError401(string message = default(string), string link = default(string), string traceId = default(string), CodeEnum code = default(CodeEnum), Object details = default(Object))
        {
            // to ensure "message" is required (not null)
            if (message == null)
            {
                throw new ArgumentNullException("message is a required property for APIError401 and cannot be null");
            }
            this.Message = message;
            // to ensure "link" is required (not null)
            if (link == null)
            {
                throw new ArgumentNullException("link is a required property for APIError401 and cannot be null");
            }
            this.Link = link;
            // to ensure "traceId" is required (not null)
            if (traceId == null)
            {
                throw new ArgumentNullException("traceId is a required property for APIError401 and cannot be null");
            }
            this.TraceId = traceId;
            this.Code = code;
            // to ensure "details" is required (not null)
            if (details == null)
            {
                throw new ArgumentNullException("details is a required property for APIError401 and cannot be null");
            }
            this.Details = details;
        }

        /// <summary>
        /// Error Message
        /// </summary>
        /// <value>Error Message</value>
        /// <example>all fields must be provided</example>
        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = true)]
        public string Message { get; set; }

        /// <summary>
        /// Link to IMX documentation that can help resolve this error
        /// </summary>
        /// <value>Link to IMX documentation that can help resolve this error</value>
        /// <example>https://docs.x.immutable.com/reference/#/</example>
        [DataMember(Name = "link", IsRequired = true, EmitDefaultValue = true)]
        public string Link { get; set; }

        /// <summary>
        /// Trace ID of the initial request
        /// </summary>
        /// <value>Trace ID of the initial request</value>
        /// <example>e47634b79a5cd6894ddc9639ec4aad26</example>
        [DataMember(Name = "trace_id", IsRequired = true, EmitDefaultValue = true)]
        public string TraceId { get; set; }

        /// <summary>
        /// Additional details to help resolve the error
        /// </summary>
        /// <value>Additional details to help resolve the error</value>
        [DataMember(Name = "details", IsRequired = true, EmitDefaultValue = true)]
        public Object Details { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class APIError401 {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Link: ").Append(Link).Append("\n");
            sb.Append("  TraceId: ").Append(TraceId).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
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
