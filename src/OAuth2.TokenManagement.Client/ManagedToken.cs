using System;
using System.Text.Json.Serialization;

namespace OAuth2.TokenManagement.Client
{
    public class ManagedToken
    {
        [JsonPropertyName("refresh_token")] 
        public string RefreshToken { get; set; }
        [JsonPropertyName("access_token")] 
        public string AccessToken { get; set; }
        [JsonPropertyName("start_date")]
        public DateTimeOffset StartDate { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonPropertyName("authority")] 
        public string Authority { get; set; }
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("expiration_date")] 
        public DateTimeOffset ExpirationDate { get; set; }
        [JsonPropertyName("token_endpoint")] 
        public string TokenEndpoint { get; set; }
    }
}
