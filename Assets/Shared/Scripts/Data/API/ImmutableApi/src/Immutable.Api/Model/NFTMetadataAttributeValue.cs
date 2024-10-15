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
using System.Reflection;

namespace Immutable.Api.Model
{
    /// <summary>
    /// The metadata trait value
    /// </summary>
    [JsonConverter(typeof(NFTMetadataAttributeValueJsonConverter))]
    [DataContract(Name = "NFTMetadataAttribute_value")]
    public partial class NFTMetadataAttributeValue : AbstractOpenAPISchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NFTMetadataAttributeValue" /> class
        /// with the <see cref="string" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of string.</param>
        public NFTMetadataAttributeValue(string actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NFTMetadataAttributeValue" /> class
        /// with the <see cref="decimal" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of decimal.</param>
        public NFTMetadataAttributeValue(decimal actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "oneOf";
            this.ActualInstance = actualInstance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NFTMetadataAttributeValue" /> class
        /// with the <see cref="bool" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of bool.</param>
        public NFTMetadataAttributeValue(bool actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "oneOf";
            this.ActualInstance = actualInstance;
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(bool) || value is bool)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(decimal) || value is decimal)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(string) || value is string)
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: bool, decimal, string");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `string`. If the actual instance is not `string`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of string</returns>
        public string GetString()
        {
            return (string)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `decimal`. If the actual instance is not `decimal`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of decimal</returns>
        public decimal GetDecimal()
        {
            return (decimal)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `bool`. If the actual instance is not `bool`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of bool</returns>
        public bool GetBool()
        {
            return (bool)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NFTMetadataAttributeValue {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, NFTMetadataAttributeValue.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of NFTMetadataAttributeValue
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of NFTMetadataAttributeValue</returns>
        public static NFTMetadataAttributeValue FromJson(string jsonString)
        {
            NFTMetadataAttributeValue newNFTMetadataAttributeValue = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newNFTMetadataAttributeValue;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(bool).GetProperty("AdditionalProperties") == null)
                {
                    newNFTMetadataAttributeValue = new NFTMetadataAttributeValue(JsonConvert.DeserializeObject<bool>(jsonString, NFTMetadataAttributeValue.SerializerSettings));
                }
                else
                {
                    newNFTMetadataAttributeValue = new NFTMetadataAttributeValue(JsonConvert.DeserializeObject<bool>(jsonString, NFTMetadataAttributeValue.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("bool");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into bool: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(decimal).GetProperty("AdditionalProperties") == null)
                {
                    newNFTMetadataAttributeValue = new NFTMetadataAttributeValue(JsonConvert.DeserializeObject<decimal>(jsonString, NFTMetadataAttributeValue.SerializerSettings));
                }
                else
                {
                    newNFTMetadataAttributeValue = new NFTMetadataAttributeValue(JsonConvert.DeserializeObject<decimal>(jsonString, NFTMetadataAttributeValue.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("decimal");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into decimal: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(string).GetProperty("AdditionalProperties") == null)
                {
                    newNFTMetadataAttributeValue = new NFTMetadataAttributeValue(JsonConvert.DeserializeObject<string>(jsonString, NFTMetadataAttributeValue.SerializerSettings));
                }
                else
                {
                    newNFTMetadataAttributeValue = new NFTMetadataAttributeValue(JsonConvert.DeserializeObject<string>(jsonString, NFTMetadataAttributeValue.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("string");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into string: {1}", jsonString, exception.ToString()));
            }

            if (match == 0)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
            }
            else if (match > 1)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` incorrectly matches more than one schema (should be exactly one match): " + String.Join(",", matchedTypes));
            }

            // deserialization is considered successful at this point if no exception has been thrown.
            return newNFTMetadataAttributeValue;
        }

    }

    /// <summary>
    /// Custom JSON converter for NFTMetadataAttributeValue
    /// </summary>
    public class NFTMetadataAttributeValueJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(NFTMetadataAttributeValue).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                    return new NFTMetadataAttributeValue(Convert.ToString(reader.Value));
                case JsonToken.Float:
                    return new NFTMetadataAttributeValue(Convert.ToDecimal(reader.Value));
                case JsonToken.Boolean:
                    return new NFTMetadataAttributeValue(Convert.ToBoolean(reader.Value));
                case JsonToken.StartObject:
                    return NFTMetadataAttributeValue.FromJson(JObject.Load(reader).ToString(Formatting.None));
                case JsonToken.StartArray:
                    return NFTMetadataAttributeValue.FromJson(JArray.Load(reader).ToString(Formatting.None));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
