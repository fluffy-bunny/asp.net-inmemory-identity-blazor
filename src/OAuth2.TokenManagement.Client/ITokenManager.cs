using System.Threading.Tasks;

namespace OAuth2.TokenManagement.Client
{
    public interface ITokenManager
    {
        Task<ManagedToken> AddManagedTokenAsync(string key, ManagedToken tokenConfig);
        Task RemoveManagedTokenAsync(string key);
        Task<ManagedToken> GetManagedTokenAsync(string key, bool forceRefresh = false);
    }
}
