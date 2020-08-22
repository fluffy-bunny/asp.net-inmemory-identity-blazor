using System.Threading.Tasks;

namespace ClientSideAuth.Services
{
    public interface IAuthHandlerHook
    {
        Task OnAuthorizedCallAsync(long seconds);
    }
}
