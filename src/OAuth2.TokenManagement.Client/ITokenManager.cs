using System.Threading.Tasks;

namespace OAuth2.TokenManagement.Client
{
    public interface ITokenManager
    {
        Task<ManagedToken> AddConcurrentManagedTokenAsync(string key, ManagedToken tokenConfig);
        Task RemoveConcurrentManagedTokenAsync(string key);
        Task<ManagedToken> GetManagedTokenAsync(string key, bool forceRefresh = false);
        Task RemoveAllConcurrentManagedTokenAsync();
    }
}
