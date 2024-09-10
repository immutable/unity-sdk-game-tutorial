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
    /// AttributeQuery
    /// </summary>
    [DataContract(Name = "AttributeQuery")]
    public partial class AttributeQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeQuery" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AttributeQuery() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeQuery" /> class.
        /// </summary>
        /// <param name="traitType">traitType (required).</param>
        /// <param name="value">value (required).</param>
        public AttributeQuery(string traitType = default(string), string value = default(string))
        {
            // to ensure "traitType" is required (not null)
            if (traitType == null)
            {
                throw new ArgumentNullException("traitType is a required property for AttributeQuery and cannot be null");
            }
            this.TraitType = traitType;
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new ArgumentNullException("value is a required property for AttributeQuery and cannot be null");
            }
            this.Value = value;
        }

        /// <summary>
        /// Gets or Sets TraitType
        /// </summary>
        /// <example>attack</example>
        [DataMember(Name = "trait_type", IsRequired = true, EmitDefaultValue = true)]
        public string TraitType { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        /// <example>1</example>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AttributeQuery {\n");
            sb.Append("  TraitType: ").Append(TraitType).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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