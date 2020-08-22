using ClientSideAuth.Services;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ClientSideAuth
{
    public class AuthorizedHandler : DelegatingHandler
    {
        private readonly AccountHelper _accountHelper;
        private readonly IAuthHandlerHook _authHandlerHook;

        public AuthorizedHandler(AccountHelper accountHelper, IAuthHandlerHook authHandlerHook)
        {
            _accountHelper = accountHelper;
            _authHandlerHook = authHandlerHook;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = await base.SendAsync(request, cancellationToken);

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized ||
                responseMessage.StatusCode == HttpStatusCode.Forbidden)
            {
                // if server returned 401 Unauthorized, redirect to login page
                _accountHelper.SignIn();
            }
            if(_authHandlerHook != null)
            {
                var query = from item in responseMessage.Headers
                           where item.Key == "x-authexpsec"
                            select item.Value;

                var authExpSec = query.FirstOrDefault();

                if(authExpSec != null)
                {
                    var sec = authExpSec.FirstOrDefault();
                    if (!string.IsNullOrEmpty(sec))
                    {
                        await _authHandlerHook.OnAuthorizedCallAsync(Convert.ToInt32(sec));
                    }
                }
            }
            return responseMessage;
        }
    }
}
