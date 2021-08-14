using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using GalleryOfLuna.Philomena.Json;
using GalleryOfLuna.Philomena.Responses;

namespace GalleryOfLuna.Philomena
{
    public partial class PhilomenaClient
    {
        private readonly Uri _baseUri;
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions();
        
        public string ApiKey { get; set; }
        
        public PhilomenaClient(Uri baseUri, string apiKey = "") : this(baseUri, apiKey, new HttpClient())
        { }
        
        public PhilomenaClient(Uri baseUri, string apiKey, HttpClient httpClient)
        {
            _baseUri = baseUri;
            ApiKey = apiKey;
            _httpClient = httpClient;

            SetupJsonOptions();
            SetupHttpClient();
        }

        private void SetupHttpClient()
        {
            _httpClient.DefaultRequestHeaders.Add("Content", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Luna's Gallery implementation of Philomena SDK for .NET v0.0.0");
        }

        private void SetupJsonOptions()
        {
            _jsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
            _jsonSerializerOptions.Converters.Add(new BigIntegerJsonConverter());
            _jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        }

        private Task<T> SendRequestAsync<T>(string requestUri, CancellationToken cancellationToken)
            where T : IPhilomenaResponse =>
            SendRequestAsync<T>(requestUri, HttpMethod.Get, cancellationToken);
        
        private async Task<T> SendRequestAsync<T>(string requestUri, HttpMethod httpMethod, CancellationToken cancellationToken)
            where T : IPhilomenaResponse
        {
            var request = new HttpRequestMessage(httpMethod, requestUri);

            var response = await _httpClient.SendAsync(request, cancellationToken);
            
            // TODO: Implement error handling on 400 code series
            // Maybe implement two different APIs - with either monad and just throwing an exception.
            response.EnsureSuccessStatusCode();

            var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
            var content = await JsonSerializer.DeserializeAsync<T>(
                contentStream,
                _jsonSerializerOptions,
                cancellationToken);
            
            Debug.Assert(content != null, "Philomena imageboard returns null response");
            return content;
        }
    }
}