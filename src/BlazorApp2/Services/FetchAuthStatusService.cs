using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp2.Services
{
    public class FetchAuthStatusService
    {
        private readonly HttpClient _httpClient;
        public FetchAuthStatusService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("authorizedClient");
        }

        public async Task<string> GetAuthStatus()
        {
            var displayName =  await _httpClient.GetFromJsonAsync<string>("api/AuthStatus");
            return displayName;
        }
    }
}
