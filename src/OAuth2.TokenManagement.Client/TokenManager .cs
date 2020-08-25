using Blazored.LocalStorage;
using IdentityModel.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OAuth2.TokenManagement.Client
{
    public class TokenManager : ITokenManager
    {
        private ILocalStorageService _localStorageService;

        public TokenManager (
            ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public async Task<ManagedToken> AddManagedTokenAsync(string key, ManagedToken managedToken)
        {
            managedToken.StartDate = DateTimeOffset.UtcNow;
            managedToken.ExpirationDate = managedToken.StartDate.AddSeconds(managedToken.ExpiresIn);
            await _localStorageService.SetItemAsync(key, managedToken);
            return managedToken;
        }
        public async Task RemoveManagedTokenAsync(string key)
        {
            await _localStorageService.RemoveItemAsync(key);
        }
        public async Task<ManagedToken> GetManagedTokenAsync(string key, bool forceRefresh = false)
        {
            try
            {


                var item = await _localStorageService.GetItemAsync<ManagedToken>(key);
                if (item == null)
                {
                    return null;
                }
                DateTimeOffset now = DateTimeOffset.UtcNow;
                if (!forceRefresh)
                {
                    if (item.ExpirationDate > now || string.IsNullOrWhiteSpace(item.RefreshToken))
                    {
                        return item;
                    }
                }

                var client = new HttpClient();
                if (string.IsNullOrWhiteSpace(item.TokenEndpoint))
                {
                    var disco = await client.GetDiscoveryDocumentAsync(item.Authority);
                    if (disco.IsError)
                        throw new Exception(disco.Error);
                    item.TokenEndpoint = disco.TokenEndpoint;
                    await _localStorageService.SetItemAsync(key, item);
                }
                var response = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
                {
                    Address = item.TokenEndpoint,
                    ClientId = item.ClientId,
                    RefreshToken = item.RefreshToken
                });
                if (response.IsError)
                    throw new Exception(response.Error);
                item.RefreshToken = response.RefreshToken;
                item.AccessToken = response.AccessToken;
                item.ExpiresIn = response.ExpiresIn;
                await AddManagedTokenAsync(key,item);
               
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
