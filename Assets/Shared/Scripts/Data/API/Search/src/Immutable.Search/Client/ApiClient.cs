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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine.Networking;
using UnityEngine;

namespace Immutable.Search.Client
{
    /// <summary>
    /// To Serialize/Deserialize JSON using our custom logic, but only when ContentType is JSON.
    /// </summary>
    internal class CustomJsonCodec
    {
        private readonly IReadableConfiguration _configuration;
        private static readonly string _contentType = "application/json";
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            }
        };

        public CustomJsonCodec(IReadableConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CustomJsonCodec(JsonSerializerSettings serializerSettings, IReadableConfiguration configuration)
        {
            _serializerSettings = serializerSettings;
            _configuration = configuration;
        }

        /// <summary>
        /// Serialize the object into a JSON string.
        /// </summary>
        /// <param name="obj">Object to be serialized.</param>
        /// <returns>A JSON string.</returns>
        public string Serialize(object obj)
        {
            if (obj != null && obj is Immutable.Search.Model.AbstractOpenAPISchema)
            {
                // the object to be serialized is an oneOf/anyOf schema
                return ((Immutable.Search.Model.AbstractOpenAPISchema)obj).ToJson();
            }
            else
            {
                return JsonConvert.SerializeObject(obj, _serializerSettings);
            }
        }

        public T Deserialize<T>(UnityWebRequest request)
        {
            var result = (T) Deserialize(request, typeof(T));
            return result;
        }

        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The UnityWebRequest after it has a response.</param>
        /// <param name="type">Object type.</param>
        /// <returns>Object representation of the JSON string.</returns>
        internal object Deserialize(UnityWebRequest request, Type type)
        {
            if (type == typeof(byte[])) // return byte array
            {
                return request.downloadHandler.data;
            }

            // TODO: ? if (type.IsAssignableFrom(typeof(Stream)))
            if (type == typeof(Stream))
            {
                // NOTE: Ignoring Content-Disposition filename support, since not all platforms
                // have a location on disk to write arbitrary data (tvOS, consoles).
                return new MemoryStream(request.downloadHandler.data);
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(request.downloadHandler.text, null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(string) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return Convert.ChangeType(request.downloadHandler.text, type);
            }

            var contentType = request.GetResponseHeader("Content-Type");

            if (!string.IsNullOrEmpty(contentType) && contentType.Contains("application/json"))
            {
                var text = request.downloadHandler?.text;

                // Generated APIs that don't expect a return value provide System.Object as the type
                if (type == typeof(global::System.Object) && (string.IsNullOrEmpty(text) || text.Trim() == "null"))
                {
                    return null;
                }

                if (request.responseCode >= 200 && request.responseCode < 300)
                {
                    try
                    {
                        // Deserialize as a model
                        return JsonConvert.DeserializeObject(text, type, _serializerSettings);
                    }
                    catch (Exception e)
                    {
                        throw new UnexpectedResponseException(request, type, e.ToString());
                    }
                }
                else
                {
                    throw new ApiException((int)request.responseCode, request.error, text);
                }
            }
            
            if (type != typeof(global::System.Object) && request.responseCode >= 200 && request.responseCode < 300)
            {
                throw new UnexpectedResponseException(request, type);
            }

            return null;

        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public string ContentType
        {
            get { return _contentType; }
            set { throw new InvalidOperationException("Not allowed to set content type."); }
        }
    }
    /// <summary>
    /// Provides a default implementation of an Api client (both synchronous and asynchronous implementations),
    /// encapsulating general REST accessor use cases.
    /// </summary>
    /// <remarks>
    /// The Dispose method will manage the HttpClient lifecycle when not passed by constructor.
    /// </remarks>
    public partial class ApiClient : IDisposable, ISynchronousClient, IAsynchronousClient
    {
        private readonly string _baseUrl;

        /// <summary>
        /// Specifies the settings on a <see cref="JsonSerializer" /> object.
        /// These settings can be adjusted to accommodate custom serialization rules.
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; set; } = new JsonSerializerSettings
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" />, defaulting to the global configurations' base url.
        /// </summary>
        public ApiClient() :
                 this(Immutable.Search.Client.GlobalConfiguration.Instance.BasePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" />.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        public ApiClient(string basePath)
        {
            if (string.IsNullOrEmpty(basePath)) throw new ArgumentException("basePath cannot be empty");

            _baseUrl = basePath;
        }

        /// <summary>
        /// Disposes resources if they were created by us
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Provides all logic for constructing a new UnityWebRequest.
        /// At this point, all information for querying the service is known. Here, it is simply
        /// mapped into the UnityWebRequest.
        /// </summary>
        /// <param name="method">The http verb.</param>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>[private] A new UnityWebRequest instance.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private UnityWebRequest NewRequest<T>(
            string method,
            string path,
            RequestOptions options,
            IReadableConfiguration configuration)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (options == null) throw new ArgumentNullException("options");
            if (configuration == null) throw new ArgumentNullException("configuration");

            WebRequestPathBuilder builder = new WebRequestPathBuilder(_baseUrl, path);

            builder.AddPathParameters(options.PathParameters);

            builder.AddQueryParameters(options.QueryParameters);

            string contentType = null;
            if (options.HeaderParameters != null && options.HeaderParameters.ContainsKey("Content-Type"))
            {
                var contentTypes = options.HeaderParameters["Content-Type"];
                contentType = contentTypes.FirstOrDefault();
            }

            var uri = builder.GetFullUri();
            UnityWebRequest request = null;

            if (contentType == "multipart/form-data")
            {
                var formData = new List<IMultipartFormSection>();
                foreach (var formParameter in options.FormParameters)
                {
                    formData.Add(new MultipartFormDataSection(formParameter.Key, formParameter.Value));
                }

                request = UnityWebRequest.Post(uri, formData);
                request.method = method;
            }
            else if (contentType == "application/x-www-form-urlencoded")
            {
                var form = new WWWForm();
                foreach (var kvp in options.FormParameters)
                {
                    form.AddField(kvp.Key, kvp.Value);
                }

                request = UnityWebRequest.Post(uri, form);
                request.method = method;
            }
            else if (options.Data != null)
            {
                var serializer = new CustomJsonCodec(SerializerSettings, configuration);
                var jsonData = serializer.Serialize(options.Data);

                // Making a post body application/json encoded is whack with UnityWebRequest.
                // See: https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
                request = UnityWebRequest.Put(uri, jsonData);
                request.method = method;
                request.SetRequestHeader("Content-Type", "application/json");
            }
            else
            {
                request = new UnityWebRequest(builder.GetFullUri(), method);
            }

            if (request.downloadHandler == null && typeof(T) != typeof(global::System.Object))
            {
                request.downloadHandler = new DownloadHandlerBuffer();
            }

#if UNITY_EDITOR || !UNITY_WEBGL
            if (configuration.UserAgent != null)
            {
                request.SetRequestHeader("User-Agent", configuration.UserAgent);
            }
#endif

            if (configuration.DefaultHeaders != null)
            {
                foreach (var headerParam in configuration.DefaultHeaders)
                {
                    request.SetRequestHeader(headerParam.Key, headerParam.Value);
                }
            }

            if (options.HeaderParameters != null)
            {
                foreach (var headerParam in options.HeaderParameters)
                {
                    foreach (var value in headerParam.Value)
                    {
                        // Todo make content headers actually content headers
                        request.SetRequestHeader(headerParam.Key, value);
                    }
                }
            }

            if (options.Cookies != null && options.Cookies.Count > 0)
            {
                #if UNITY_WEBGL
                throw new System.InvalidOperationException("UnityWebRequest does not support setting cookies in WebGL");
                #else
                if (options.Cookies.Count != 1)
                {
                    UnityEngine.Debug.LogError("Only one cookie supported, ignoring others");
                }

                request.SetRequestHeader("Cookie", options.Cookies[0].ToString());
                #endif
            }

            return request;

        }

        partial void InterceptRequest(UnityWebRequest req, string path, RequestOptions options, IReadableConfiguration configuration);
        partial void InterceptResponse(UnityWebRequest req, string path, RequestOptions options, IReadableConfiguration configuration, ref object responseData);

        private ApiResponse<T> ToApiResponse<T>(UnityWebRequest request, object responseData)
        {
            T result = (T) responseData;

            var transformed = new ApiResponse<T>((HttpStatusCode)request.responseCode, new Multimap<string, string>(), result, request.downloadHandler?.text ?? "")
            {
                ErrorText = request.error,
                Cookies = new List<Cookie>()
            };

            // process response headers, e.g. Access-Control-Allow-Methods
            var responseHeaders = request.GetResponseHeaders();
            if (responseHeaders != null)
            {
                foreach (var responseHeader in request.GetResponseHeaders())
                {
                    transformed.Headers.Add(responseHeader.Key, ClientUtils.ParameterToString(responseHeader.Value));
                }
            }

            return transformed;
        }

        private async Task<ApiResponse<T>> ExecAsync<T>(
            UnityWebRequest request,
            string path,
            RequestOptions options,
            IReadableConfiguration configuration,
            System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            var deserializer = new CustomJsonCodec(SerializerSettings, configuration);

            using (request)
            {
                if (configuration.Timeout > 0)
                {
                    request.timeout = (int)Math.Ceiling(configuration.Timeout / 1000.0f);
                }

                if (configuration.Proxy != null)
                {
                    throw new InvalidOperationException("Configuration `Proxy` not supported by UnityWebRequest");
                }

                if (configuration.ClientCertificates != null)
                {
                    // Only Android/iOS/tvOS/Standalone players can support certificates, and this
                    // implementation is intended to work on all platforms.
                    //
                    // TODO: Could optionally allow support for this on these platforms.
                    //
                    // See: https://docs.unity3d.com/ScriptReference/Networking.CertificateHandler.html
                    throw new InvalidOperationException("Configuration `ClientCertificates` not supported by UnityWebRequest on all platforms");
                }

                InterceptRequest(request, path, options, configuration);

                var asyncOp = request.SendWebRequest();

                TaskCompletionSource<UnityWebRequest.Result> tsc = new TaskCompletionSource<UnityWebRequest.Result>();
                asyncOp.completed += (_) => tsc.TrySetResult(request.result);

                using (var tokenRegistration = cancellationToken.Register(request.Abort, true))
                {
                    await tsc.Task;
                }
                
                if (request.result == UnityWebRequest.Result.ConnectionError ||
                    request.result == UnityWebRequest.Result.DataProcessingError)
                {
                    throw new ConnectionException(request);
                }

                object responseData = deserializer.Deserialize<T>(request);

                // if the response type is oneOf/anyOf, call FromJSON to deserialize the data
                if (typeof(Immutable.Search.Model.AbstractOpenAPISchema).IsAssignableFrom(typeof(T)))
                {
                    responseData = (T) typeof(T).GetMethod("FromJson").Invoke(null, new object[] { new ByteArrayContent(request.downloadHandler.data) });
                }
                else if (typeof(T).Name == "Stream") // for binary response
                {
                    responseData = (T) (object) new MemoryStream(request.downloadHandler.data);
                }

                InterceptResponse(request, path, options, configuration, ref responseData);

                return ToApiResponse<T>(request, responseData);
            }
        }

        #region IAsynchronousClient
        /// <summary>
        /// Make a HTTP GET request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> GetAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest<T>("GET", path, options, config), path, options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP POST request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PostAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest<T>("POST", path, options, config), path, options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP PUT request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PutAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest<T>("PUT", path, options, config), path, options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP DELETE request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> DeleteAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest<T>("DELETE", path, options, config), path, options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP HEAD request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> HeadAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest<T>("HEAD", path, options, config), path, options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP OPTION request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> OptionsAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest<T>("OPTIONS", path, options, config), path, options, config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP PATCH request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PatchAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest<T>("PATCH", path, options, config), path, options, config, cancellationToken);
        }
        #endregion IAsynchronousClient

        #region ISynchronousClient
        /// <summary>
        /// Make a HTTP GET request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Get<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            throw new System.NotImplementedException("UnityWebRequest does not support synchronous operation");
        }

        /// <summary>
        /// Make a HTTP POST request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Post<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            throw new System.NotImplementedException("UnityWebRequest does not support synchronous operation");
        }

        /// <summary>
        /// Make a HTTP PUT request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Put<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            throw new System.NotImplementedException("UnityWebRequest does not support synchronous operation");
        }

        /// <summary>
        /// Make a HTTP DELETE request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Delete<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            throw new System.NotImplementedException("UnityWebRequest does not support synchronous operation");
        }

        /// <summary>
        /// Make a HTTP HEAD request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Head<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            throw new System.NotImplementedException("UnityWebRequest does not support synchronous operation");
        }

        /// <summary>
        /// Make a HTTP OPTION request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Options<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            throw new System.NotImplementedException("UnityWebRequest does not support synchronous operation");
        }

        /// <summary>
        /// Make a HTTP PATCH request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Patch<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            throw new System.NotImplementedException("UnityWebRequest does not support synchronous operation");
        }
        #endregion ISynchronousClient
    }
}