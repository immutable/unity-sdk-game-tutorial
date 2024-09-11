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
using System.Reflection;

namespace Immutable.Ts.Model
{
    /// <summary>
    /// PrepareListingResBodyAction
    /// </summary>
    [JsonConverter(typeof(PrepareListingResBodyActionJsonConverter))]
    [DataContract(Name = "prepareListingResBodyAction")]
    public partial class PrepareListingResBodyAction : AbstractOpenAPISchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareListingResBodyAction" /> class
        /// with the <see cref="PrepareListingResBodyTransactionAction" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of PrepareListingResBodyTransactionAction.</param>
        public PrepareListingResBodyAction(PrepareListingResBodyTransactionAction actualInstance)
        {
            IsNullable = false;
            SchemaType = "anyOf";
            ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareListingResBodyAction" /> class
        /// with the <see cref="PrepareListingResBodySignableAction" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of PrepareListingResBodySignableAction.</param>
        public PrepareListingResBodyAction(PrepareListingResBodySignableAction actualInstance)
        {
            IsNullable = false;
            SchemaType = "anyOf";
            ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
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
                if (value.GetType() == typeof(PrepareListingResBodySignableAction))
                {
                    _actualInstance = value;
                }
                else if (value.GetType() == typeof(PrepareListingResBodyTransactionAction))
                {
                    _actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: PrepareListingResBodySignableAction, PrepareListingResBodyTransactionAction");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `PrepareListingResBodyTransactionAction`. If the actual instance is not `PrepareListingResBodyTransactionAction`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of PrepareListingResBodyTransactionAction</returns>
        public PrepareListingResBodyTransactionAction GetPrepareListingResBodyTransactionAction()
        {
            return (PrepareListingResBodyTransactionAction)ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `PrepareListingResBodySignableAction`. If the actual instance is not `PrepareListingResBodySignableAction`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of PrepareListingResBodySignableAction</returns>
        public PrepareListingResBodySignableAction GetPrepareListingResBodySignableAction()
        {
            return (PrepareListingResBodySignableAction)ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PrepareListingResBodyAction {\n");
            sb.Append("  ActualInstance: ").Append(ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(ActualInstance, PrepareListingResBodyAction.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of PrepareListingResBodyAction
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of PrepareListingResBodyAction</returns>
        public static PrepareListingResBodyAction FromJson(string jsonString)
        {
            PrepareListingResBodyAction newPrepareListingResBodyAction = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newPrepareListingResBodyAction;
            }

            try
            {
                newPrepareListingResBodyAction = new PrepareListingResBodyAction(JsonConvert.DeserializeObject<PrepareListingResBodySignableAction>(jsonString, PrepareListingResBodyAction.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newPrepareListingResBodyAction;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into PrepareListingResBodySignableAction: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newPrepareListingResBodyAction = new PrepareListingResBodyAction(JsonConvert.DeserializeObject<PrepareListingResBodyTransactionAction>(jsonString, PrepareListingResBodyAction.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newPrepareListingResBodyAction;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into PrepareListingResBodyTransactionAction: {1}", jsonString, exception.ToString()));
            }

            // no match found, throw an exception
            throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
        }

    }

    /// <summary>
    /// Custom JSON converter for PrepareListingResBodyAction
    /// </summary>
    public class PrepareListingResBodyActionJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(PrepareListingResBodyAction).GetMethod("ToJson").Invoke(value, null)));
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
                    return PrepareListingResBodyAction.FromJson(JObject.Load(reader).ToString(Formatting.None));
                case JsonToken.StartArray:
                    return PrepareListingResBodyAction.FromJson(JArray.Load(reader).ToString(Formatting.None));
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