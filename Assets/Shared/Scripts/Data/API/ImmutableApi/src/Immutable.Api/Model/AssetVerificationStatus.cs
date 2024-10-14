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
    /// The verification status for a given contract
    /// </summary>
    /// <value>The verification status for a given contract</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssetVerificationStatus
    {
        /// <summary>
        /// Enum Verified for value: verified
        /// </summary>
        [EnumMember(Value = "verified")]
        Verified = 1,

        /// <summary>
        /// Enum Unverified for value: unverified
        /// </summary>
        [EnumMember(Value = "unverified")]
        Unverified = 2,

        /// <summary>
        /// Enum Spam for value: spam
        /// </summary>
        [EnumMember(Value = "spam")]
        Spam = 3,

        /// <summary>
        /// Enum Inactive for value: inactive
        /// </summary>
        [EnumMember(Value = "inactive")]
        Inactive = 4
    }

}
