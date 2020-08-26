using IdentityModel.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Client;
using static Common.Client.TimedLock;

namespace OAuth2.TokenManagement.Client
{
    public class TokenManager : ITokenManager
    {
        const string MapKey = "4b9f6949-e3fe-40fa-b59a-f845f1704c33";
        static TimedLock _lock = new TimedLock();
        private ConcurrentDictionary<string, ManagedToken> _managedTokens { get; set; }
        public TokenManager ( )
        {
            _managedTokens = new ConcurrentDictionary<string, ManagedToken>();
        }
        public async Task<ManagedToken> AddConcurrentManagedTokenAsync(string key, ManagedToken managedToken)
        {
            LockReleaser releaser = await _lock.Lock(new TimeSpan(0, 0, 30));
            try
            {
               
                managedToken.StartDate = DateTimeOffset.UtcNow;
                managedToken.ExpirationDate = managedToken.StartDate.AddSeconds(managedToken.ExpiresIn);
                _managedTokens[key] = managedToken;
                return managedToken;
            }
            finally
            {
                releaser.Dispose();
            }
        }
        private async Task<ManagedToken> GetConcurrentManagedTokenAsync(string key)
        {
            LockReleaser releaser = await _lock.Lock(new TimeSpan(0, 0, 30));
            try
            {
                ManagedToken managedToken;
                if (_managedTokens.TryGetValue(key, out managedToken))
                {
                    return managedToken;
                }
                return null;
            }
            finally
            {
                releaser.Dispose();
            }
        }
        public async Task RemoveConcurrentManagedTokenAsync(string key)
        {
            LockReleaser releaser = await _lock.Lock(new TimeSpan(0, 0, 30));
            try
            {
                _managedTokens.TryRemove(key, out _);
            }
            finally
            {
                releaser.Dispose();
            }
        }
        public async Task<ManagedToken> GetManagedTokenAsync(string key, bool forceRefresh = false)
        {
            try
            {
                var managedToken = await GetConcurrentManagedTokenAsync(key);
                if (managedToken == null)
                {
                    return null;
                }


                DateTimeOffset now = DateTimeOffset.UtcNow;
                if (!forceRefresh)
                {
                    if (managedToken.ExpirationDate > now || string.IsNullOrWhiteSpace(managedToken.RefreshToken))
                    {
                        return managedToken;
                    }
                }
                var client = new HttpClient();
                if (string.IsNullOrWhiteSpace(managedToken.TokenEndpoint))
                {
                    var disco = await client.GetDiscoveryDocumentAsync(managedToken.Authority);
                    if (disco.IsError)
                        throw new Exception(disco.Error);
                    managedToken.TokenEndpoint = disco.TokenEndpoint;
                }
                var response = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
                {
                    Address = managedToken.TokenEndpoint,
                    ClientId = managedToken.ClientId,
                    RefreshToken = managedToken.RefreshToken
                });
                if (response.IsError)
                    throw new Exception(response.Error);
                managedToken.RefreshToken = response.RefreshToken;
                managedToken.AccessToken = response.AccessToken;
                managedToken.ExpiresIn = response.ExpiresIn;
                managedToken = await AddConcurrentManagedTokenAsync(key, managedToken);
                return managedToken;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task RemoveAllConcurrentManagedTokenAsync()
        {
            LockReleaser releaser = await _lock.Lock(new TimeSpan(0, 0, 30));
            try
            {
                _managedTokens.Clear();
            }
            finally
            {
                releaser.Dispose();
            }
        }
    }
}
