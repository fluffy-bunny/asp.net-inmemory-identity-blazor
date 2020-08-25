using System.Threading.Tasks;

namespace ClientSideAuth.Services
{
    public interface IAuthHandlerStateSink
    {
        Task OnAuthenticatedAsync(bool authenticated);
    }
}
