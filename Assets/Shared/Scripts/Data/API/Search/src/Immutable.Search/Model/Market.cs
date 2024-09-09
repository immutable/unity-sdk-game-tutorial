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
    /// Market data
    /// </summary>
    [DataContract(Name = "Market")]
    public partial class Market
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Market" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Market() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Market" /> class.
        /// </summary>
        /// <param name="floorListing">floorListing (required).</param>
        /// <param name="lastTrade">lastTrade (required).</param>
        public Market(Listing floorListing = default(Listing), LastTrade lastTrade = default(LastTrade))
        {
            // to ensure "floorListing" is required (not null)
            if (floorListing == null)
            {
                throw new ArgumentNullException("floorListing is a required property for Market and cannot be null");
            }
            this.FloorListing = floorListing;
            // to ensure "lastTrade" is required (not null)
            if (lastTrade == null)
            {
                throw new ArgumentNullException("lastTrade is a required property for Market and cannot be null");
            }
            this.LastTrade = lastTrade;
        }

        /// <summary>
        /// Gets or Sets FloorListing
        /// </summary>
        [DataMember(Name = "floor_listing", IsRequired = true, EmitDefaultValue = true)]
        public Listing FloorListing { get; set; }

        /// <summary>
        /// Gets or Sets LastTrade
        /// </summary>
        [DataMember(Name = "last_trade", IsRequired = true, EmitDefaultValue = true)]
        public LastTrade LastTrade { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Market {\n");
            sb.Append("  FloorListing: ").Append(FloorListing).Append("\n");
            sb.Append("  LastTrade: ").Append(LastTrade).Append("\n");
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
