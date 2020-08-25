using ClientSideAuth.Services;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ClientSideAuth
{
    public class AuthorizedHandler : DelegatingHandler
    {
        private readonly AccountHelper _accountHelper;
        private readonly IAuthHandlerHook _authHandlerHook;
        private readonly List<IAuthHandlerStateSink> _authHandlerStateSinks;

        public AuthorizedHandler(AccountHelper accountHelper, IAuthHandlerHook authHandlerHook,IEnumerable<IAuthHandlerStateSink> authHandlerStateSinks)
        {
            _accountHelper = accountHelper;
            _authHandlerHook = authHandlerHook;
            _authHandlerStateSinks = authHandlerStateSinks.ToList();
        }
        int? CheckForAuthSeconds(HttpResponseMessage responseMessage)
        {
            var query = from item in responseMessage.Headers
                        where item.Key == "x-authexpsec"
                        select item.Value;

            var authExpSec = query.FirstOrDefault();

            if (authExpSec != null)
            {
                var sec = authExpSec.FirstOrDefault();
                if (!string.IsNullOrEmpty(sec))
                {
                    return Convert.ToInt32(sec);
                }
            }
            return null;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = await base.SendAsync(request, cancellationToken);
            int? authSeconds = CheckForAuthSeconds(responseMessage);
            if(authSeconds == null)
            {
                // not authenicated
                foreach (var sink in _authHandlerStateSinks)
                {
                    await sink.OnAuthenticatedAsync(false);
                }
            }
            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized ||
                responseMessage.StatusCode == HttpStatusCode.Forbidden)
            {
                // if server returned 401 Unauthorized, redirect to login page
                _accountHelper.SignIn();
                return null;
            }
            else
            {
                if (_authHandlerHook != null)
                {
                    var query = from item in responseMessage.Headers
                                where item.Key == "x-authexpsec"
                                select item.Value;

                    var authExpSec = query.FirstOrDefault();

                    if (authExpSec != null)
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
}
