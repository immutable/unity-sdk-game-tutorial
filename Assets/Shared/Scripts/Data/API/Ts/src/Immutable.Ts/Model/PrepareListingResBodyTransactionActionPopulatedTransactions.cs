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
    /// PrepareListingResBodyTransactionActionPopulatedTransactions
    /// </summary>
    [DataContract(Name = "prepareListingResBodyTransactionAction_populatedTransactions")]
    public partial class PrepareListingResBodyTransactionActionPopulatedTransactions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareListingResBodyTransactionActionPopulatedTransactions" /> class.
        /// </summary>
        /// <param name="to">to.</param>
        /// <param name="from">from.</param>
        /// <param name="nonce">nonce.</param>
        /// <param name="gasLimit">gasLimit.</param>
        /// <param name="gasPrice">gasPrice.</param>
        /// <param name="data">data.</param>
        /// <param name="value">value.</param>
        /// <param name="chainId">chainId.</param>
        /// <param name="type">type.</param>
        /// <param name="accessList">accessList.</param>
        /// <param name="maxFeePerGas">maxFeePerGas.</param>
        /// <param name="maxPriorityFeePerGas">maxPriorityFeePerGas.</param>
        /// <param name="customData">customData.</param>
        /// <param name="ccipReadEnabled">ccipReadEnabled.</param>
        public PrepareListingResBodyTransactionActionPopulatedTransactions(string to = default(string), string from = default(string), decimal nonce = default(decimal), string gasLimit = default(string), string gasPrice = default(string), string data = default(string), string value = default(string), decimal chainId = default(decimal), decimal type = default(decimal), List<PrepareListingResBodyTransactionActionPopulatedTransactionsAccessListInner> accessList = default(List<PrepareListingResBodyTransactionActionPopulatedTransactionsAccessListInner>), string maxFeePerGas = default(string), string maxPriorityFeePerGas = default(string), Dictionary<string, Object> customData = default(Dictionary<string, Object>), bool ccipReadEnabled = default(bool))
        {
            this.To = to;
            this.From = from;
            this.Nonce = nonce;
            this.GasLimit = gasLimit;
            this.GasPrice = gasPrice;
            this.Data = data;
            this.Value = value;
            this.ChainId = chainId;
            this.Type = type;
            this.AccessList = accessList;
            this.MaxFeePerGas = maxFeePerGas;
            this.MaxPriorityFeePerGas = maxPriorityFeePerGas;
            this.CustomData = customData;
            this.CcipReadEnabled = ccipReadEnabled;
        }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        public string To { get; set; }

        /// <summary>
        /// Gets or Sets From
        /// </summary>
        [DataMember(Name = "from", EmitDefaultValue = false)]
        public string From { get; set; }

        /// <summary>
        /// Gets or Sets Nonce
        /// </summary>
        [DataMember(Name = "nonce", EmitDefaultValue = false)]
        public decimal Nonce { get; set; }

        /// <summary>
        /// Gets or Sets GasLimit
        /// </summary>
        [DataMember(Name = "gasLimit", EmitDefaultValue = false)]
        public string GasLimit { get; set; }

        /// <summary>
        /// Gets or Sets GasPrice
        /// </summary>
        [DataMember(Name = "gasPrice", EmitDefaultValue = false)]
        public string GasPrice { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public string Data { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chainId", EmitDefaultValue = false)]
        public decimal ChainId { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public decimal Type { get; set; }

        /// <summary>
        /// Gets or Sets AccessList
        /// </summary>
        [DataMember(Name = "accessList", EmitDefaultValue = false)]
        public List<PrepareListingResBodyTransactionActionPopulatedTransactionsAccessListInner> AccessList { get; set; }

        /// <summary>
        /// Gets or Sets MaxFeePerGas
        /// </summary>
        [DataMember(Name = "maxFeePerGas", EmitDefaultValue = false)]
        public string MaxFeePerGas { get; set; }

        /// <summary>
        /// Gets or Sets MaxPriorityFeePerGas
        /// </summary>
        [DataMember(Name = "maxPriorityFeePerGas", EmitDefaultValue = false)]
        public string MaxPriorityFeePerGas { get; set; }

        /// <summary>
        /// Gets or Sets CustomData
        /// </summary>
        [DataMember(Name = "customData", EmitDefaultValue = false)]
        public Dictionary<string, Object> CustomData { get; set; }

        /// <summary>
        /// Gets or Sets CcipReadEnabled
        /// </summary>
        [DataMember(Name = "ccipReadEnabled", EmitDefaultValue = true)]
        public bool CcipReadEnabled { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PrepareListingResBodyTransactionActionPopulatedTransactions {\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  Nonce: ").Append(Nonce).Append("\n");
            sb.Append("  GasLimit: ").Append(GasLimit).Append("\n");
            sb.Append("  GasPrice: ").Append(GasPrice).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  AccessList: ").Append(AccessList).Append("\n");
            sb.Append("  MaxFeePerGas: ").Append(MaxFeePerGas).Append("\n");
            sb.Append("  MaxPriorityFeePerGas: ").Append(MaxPriorityFeePerGas).Append("\n");
            sb.Append("  CustomData: ").Append(CustomData).Append("\n");
            sb.Append("  CcipReadEnabled: ").Append(CcipReadEnabled).Append("\n");
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