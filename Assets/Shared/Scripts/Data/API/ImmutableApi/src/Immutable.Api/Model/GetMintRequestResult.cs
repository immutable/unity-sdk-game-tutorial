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
    /// GetMintRequestResult
    /// </summary>
    [DataContract(Name = "GetMintRequestResult")]
    public partial class GetMintRequestResult
    {

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
        public MintRequestStatus Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMintRequestResult" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetMintRequestResult() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMintRequestResult" /> class.
        /// </summary>
        /// <param name="chain">chain (required).</param>
        /// <param name="collectionAddress">The address of the contract (required).</param>
        /// <param name="referenceId">The reference id of this mint request (required).</param>
        /// <param name="ownerAddress">The address of the owner of the NFT (required).</param>
        /// <param name="tokenId">An &#x60;uint256&#x60; token id as string. Only available when the mint request succeeds (required).</param>
        /// <param name="amount">An &#x60;uint256&#x60; amount as string. Only relevant for mint requests on ERC1155 contracts.</param>
        /// <param name="activityId">The id of the mint activity associated with this mint request.</param>
        /// <param name="transactionHash">The transaction hash of the activity (required).</param>
        /// <param name="createdAt">When the mint request was created (required).</param>
        /// <param name="updatedAt">When the mint request was last updated (required).</param>
        /// <param name="error">error (required).</param>
        /// <param name="status">status (required).</param>
        public GetMintRequestResult(Chain chain = default(Chain), string collectionAddress = default(string), string referenceId = default(string), string ownerAddress = default(string), string tokenId = default(string), string amount = default(string), Guid? activityId = default(Guid?), string transactionHash = default(string), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime), MintRequestErrorMessage error = default(MintRequestErrorMessage), MintRequestStatus status = default(MintRequestStatus))
        {
            // to ensure "chain" is required (not null)
            if (chain == null)
            {
                throw new ArgumentNullException("chain is a required property for GetMintRequestResult and cannot be null");
            }
            this.Chain = chain;
            // to ensure "collectionAddress" is required (not null)
            if (collectionAddress == null)
            {
                throw new ArgumentNullException("collectionAddress is a required property for GetMintRequestResult and cannot be null");
            }
            this.CollectionAddress = collectionAddress;
            // to ensure "referenceId" is required (not null)
            if (referenceId == null)
            {
                throw new ArgumentNullException("referenceId is a required property for GetMintRequestResult and cannot be null");
            }
            this.ReferenceId = referenceId;
            // to ensure "ownerAddress" is required (not null)
            if (ownerAddress == null)
            {
                throw new ArgumentNullException("ownerAddress is a required property for GetMintRequestResult and cannot be null");
            }
            this.OwnerAddress = ownerAddress;
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for GetMintRequestResult and cannot be null");
            }
            this.TokenId = tokenId;
            // to ensure "transactionHash" is required (not null)
            if (transactionHash == null)
            {
                throw new ArgumentNullException("transactionHash is a required property for GetMintRequestResult and cannot be null");
            }
            this.TransactionHash = transactionHash;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            // to ensure "error" is required (not null)
            if (error == null)
            {
                throw new ArgumentNullException("error is a required property for GetMintRequestResult and cannot be null");
            }
            this.Error = error;
            this.Status = status;
            this.Amount = amount;
            this.ActivityId = activityId;
        }

        /// <summary>
        /// Gets or Sets Chain
        /// </summary>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public Chain Chain { get; set; }

        /// <summary>
        /// The address of the contract
        /// </summary>
        /// <value>The address of the contract</value>
        /// <example>0x8a90cab2b38dba80c64b7734e58ee1db38b8992e</example>
        [DataMember(Name = "collection_address", IsRequired = true, EmitDefaultValue = true)]
        public string CollectionAddress { get; set; }

        /// <summary>
        /// The reference id of this mint request
        /// </summary>
        /// <value>The reference id of this mint request</value>
        [DataMember(Name = "reference_id", IsRequired = true, EmitDefaultValue = true)]
        public string ReferenceId { get; set; }

        /// <summary>
        /// The address of the owner of the NFT
        /// </summary>
        /// <value>The address of the owner of the NFT</value>
        [DataMember(Name = "owner_address", IsRequired = true, EmitDefaultValue = true)]
        public string OwnerAddress { get; set; }

        /// <summary>
        /// An &#x60;uint256&#x60; token id as string. Only available when the mint request succeeds
        /// </summary>
        /// <value>An &#x60;uint256&#x60; token id as string. Only available when the mint request succeeds</value>
        /// <example>1</example>
        [DataMember(Name = "token_id", IsRequired = true, EmitDefaultValue = true)]
        public string TokenId { get; set; }

        /// <summary>
        /// An &#x60;uint256&#x60; amount as string. Only relevant for mint requests on ERC1155 contracts
        /// </summary>
        /// <value>An &#x60;uint256&#x60; amount as string. Only relevant for mint requests on ERC1155 contracts</value>
        /// <example>1</example>
        [DataMember(Name = "amount", EmitDefaultValue = true)]
        public string Amount { get; set; }

        /// <summary>
        /// The id of the mint activity associated with this mint request
        /// </summary>
        /// <value>The id of the mint activity associated with this mint request</value>
        /// <example>4e28df8d-f65c-4c11-ba04-6a9dd47b179b</example>
        [DataMember(Name = "activity_id", EmitDefaultValue = true)]
        public Guid? ActivityId { get; set; }

        /// <summary>
        /// The transaction hash of the activity
        /// </summary>
        /// <value>The transaction hash of the activity</value>
        /// <example>0x68d9eac5e3b3c3580404989a4030c948a78e1b07b2b5ea5688d8c38a6c61c93e</example>
        [DataMember(Name = "transaction_hash", IsRequired = true, EmitDefaultValue = true)]
        public string TransactionHash { get; set; }

        /// <summary>
        /// When the mint request was created
        /// </summary>
        /// <value>When the mint request was created</value>
        /// <example>2022-08-16T17:43:26.991388Z</example>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the mint request was last updated
        /// </summary>
        /// <value>When the mint request was last updated</value>
        /// <example>2022-08-16T17:43:26.991388Z</example>
        [DataMember(Name = "updated_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets Error
        /// </summary>
        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = true)]
        public MintRequestErrorMessage Error { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetMintRequestResult {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  CollectionAddress: ").Append(CollectionAddress).Append("\n");
            sb.Append("  ReferenceId: ").Append(ReferenceId).Append("\n");
            sb.Append("  OwnerAddress: ").Append(OwnerAddress).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  ActivityId: ").Append(ActivityId).Append("\n");
            sb.Append("  TransactionHash: ").Append(TransactionHash).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
