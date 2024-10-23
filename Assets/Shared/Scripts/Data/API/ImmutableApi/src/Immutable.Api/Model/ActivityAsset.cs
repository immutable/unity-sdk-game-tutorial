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
    /// The contract and asset details for this activity
    /// </summary>
    [JsonConverter(typeof(ActivityAssetJsonConverter))]
    [DataContract(Name = "ActivityAsset")]
    public partial class ActivityAsset : AbstractOpenAPISchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityAsset" /> class
        /// with the <see cref="ActivityNFT" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of ActivityNFT.</param>
        public ActivityAsset(ActivityNFT actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityAsset" /> class
        /// with the <see cref="ActivityToken" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of ActivityToken.</param>
        public ActivityAsset(ActivityToken actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
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
                if (value.GetType() == typeof(ActivityNFT) || value is ActivityNFT)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(ActivityToken) || value is ActivityToken)
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: ActivityNFT, ActivityToken");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `ActivityNFT`. If the actual instance is not `ActivityNFT`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of ActivityNFT</returns>
        public ActivityNFT GetActivityNFT()
        {
            return (ActivityNFT)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `ActivityToken`. If the actual instance is not `ActivityToken`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of ActivityToken</returns>
        public ActivityToken GetActivityToken()
        {
            return (ActivityToken)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ActivityAsset {\n");
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
            return JsonConvert.SerializeObject(this.ActualInstance, ActivityAsset.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of ActivityAsset
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of ActivityAsset</returns>
        public static ActivityAsset FromJson(string jsonString)
        {
            ActivityAsset newActivityAsset = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newActivityAsset;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(ActivityNFT).GetProperty("AdditionalProperties") == null)
                {
                    newActivityAsset = new ActivityAsset(JsonConvert.DeserializeObject<ActivityNFT>(jsonString, ActivityAsset.SerializerSettings));
                }
                else
                {
                    newActivityAsset = new ActivityAsset(JsonConvert.DeserializeObject<ActivityNFT>(jsonString, ActivityAsset.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("ActivityNFT");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into ActivityNFT: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(ActivityToken).GetProperty("AdditionalProperties") == null)
                {
                    newActivityAsset = new ActivityAsset(JsonConvert.DeserializeObject<ActivityToken>(jsonString, ActivityAsset.SerializerSettings));
                }
                else
                {
                    newActivityAsset = new ActivityAsset(JsonConvert.DeserializeObject<ActivityToken>(jsonString, ActivityAsset.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("ActivityToken");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into ActivityToken: {1}", jsonString, exception.ToString()));
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
            return newActivityAsset;
        }

    }

    /// <summary>
    /// Custom JSON converter for ActivityAsset
    /// </summary>
    public class ActivityAssetJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(ActivityAsset).GetMethod("ToJson").Invoke(value, null)));
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
                case JsonToken.StartObject:
                    return ActivityAsset.FromJson(JObject.Load(reader).ToString(Formatting.None));
                case JsonToken.StartArray:
                    return ActivityAsset.FromJson(JArray.Load(reader).ToString(Formatting.None));
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
