using ClientSideAuth.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2.TokenManagement.Client
{
    class TokenManagerAuthHandlerStateSink : IAuthHandlerStateSink
    {
        private ITokenManager _tokenManager;

        public TokenManagerAuthHandlerStateSink(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }
        public async Task OnAuthenticatedAsync(bool authenticated)
        {
            if (!authenticated) { }
            await _tokenManager.RemoveAllConcurrentManagedTokenAsync(); 
        }
 
    }
}
