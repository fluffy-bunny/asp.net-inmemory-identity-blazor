using BazorAuth.Shared;
using ClientSideAuth;
using OAuth2.TokenManagement.Client;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorAppRealTime.Services
{
    public class FetchAuthStatusService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenManager _tokenManager;

        public FetchAuthStatusService(IHostHttpClient hostHttpClient,
             OAuth2.TokenManagement.Client.ITokenManager tokenManager)
        {
            _httpClient = hostHttpClient.CreateHttpClient();
            _tokenManager = tokenManager;
        }

        public async Task PingAsync()
        {
            await _httpClient.GetAsync("api/AuthStatus/ping");
        }
        public async Task<string> GetUserDisplayNameStatus()
        {
            var displayName = await _httpClient.GetFromJsonAsync<string>("api/AuthStatus/display-name");
            return displayName;
        }
        public async Task<ClaimHandle[]> GetClaimsAsync()
        {
            var claims = await _httpClient.GetFromJsonAsync<ClaimHandle[]>("api/AuthStatus/claims");
            return claims;
        }
        public async Task<OpenIdConnectSessionDetails> GetOpenIdConnectSessionDetailsAsync()
        {
            var openIdConnectSessionDetails = await _httpClient.GetFromJsonAsync<OpenIdConnectSessionDetails>("api/AuthStatus/oidc-session-details");
            return openIdConnectSessionDetails;
        }
        public async Task<ManagedToken> FetchFakeBearerTokenAsync()
        {
            var managedToken = await _httpClient.GetFromJsonAsync<ManagedToken>("api/FakeOAuth2/fake-bearer-token");
            managedToken = await _tokenManager.AddConcurrentManagedTokenAsync("fake", managedToken);
            return managedToken;
        }
        public async Task<ManagedToken> GetFakeManagedTokenAsync()
        {
            var managedToken = await _tokenManager.GetManagedTokenAsync("fake");
            return managedToken;
        }
    }
}
