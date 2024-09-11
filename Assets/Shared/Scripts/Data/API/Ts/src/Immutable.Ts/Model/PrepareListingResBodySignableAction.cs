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
    /// PrepareListingResBodySignableAction
    /// </summary>
    [DataContract(Name = "prepareListingResBodySignableAction")]
    public partial class PrepareListingResBodySignableAction
    {

        /// <summary>
        /// Gets or Sets Purpose
        /// </summary>
        [DataMember(Name = "purpose", EmitDefaultValue = false)]
        public PrepareListingResBodySignablePurpose? Purpose { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareListingResBodySignableAction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PrepareListingResBodySignableAction() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareListingResBodySignableAction" /> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="purpose">purpose.</param>
        /// <param name="type">type (required).</param>
        public PrepareListingResBodySignableAction(PrepareListingResBodySignableActionMessage message = default(PrepareListingResBodySignableActionMessage), PrepareListingResBodySignablePurpose? purpose = default(PrepareListingResBodySignablePurpose?), string type = default(string))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for PrepareListingResBodySignableAction and cannot be null");
            }
            this.Type = type;
            this.Message = message;
            this.Purpose = purpose;
        }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public PrepareListingResBodySignableActionMessage Message { get; set; }

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
            sb.Append("class PrepareListingResBodySignableAction {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Purpose: ").Append(Purpose).Append("\n");
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