using DadJokes.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Polly;


namespace DadJokes.Clients
{
    public class JokesClient : IJokesClient
    {

        private readonly HttpClient _httpClient;        
        private readonly IOptions<ApiSettings> _apiSettings;
        private readonly IAsyncPolicy<HttpResponseMessage> _policy;

        public JokesClient(IAsyncPolicy<HttpResponseMessage> policy,HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            this._httpClient = httpClient;
            this._apiSettings = apiSettings;
            this._policy = policy;
        }

        public async Task<ApiDto> GetJokesResponseAsync()
        {            
            string? responseContent = string.Empty;
            
            var request = new HttpRequestMessage
            {
               Method = HttpMethod.Get,
               RequestUri = new Uri(this._apiSettings.Value?.RequestUri ?? String.Empty),
               Headers =
               {
                    { "X-RapidAPI-Key", this._apiSettings.Value?.Key ?? String.Empty},
                    { "X-RapidAPI-Host", this._apiSettings.Value?.Host ?? String.Empty},
               },
             };

            using (var response = await _policy.ExecuteAsync(() => _httpClient.SendAsync(request)))
            {
                HttpResponseMessage code = response.EnsureSuccessStatusCode();
                responseContent = code.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : String.Empty;
            }

           
            ApiDto result = JsonConvert.DeserializeObject<ApiDto>(responseContent);
             
           return result;
        }        
    }
}