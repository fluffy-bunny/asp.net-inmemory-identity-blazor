using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InMemoryIdentityApp.Authorization
{
    public class AuthenticationPeekOptions
    {
        public string CookieAuthExpirationSeconds { get; set; }
    }
    public class AuthenticationPeekMiddleware
    {
        // Property key is used by Endpoint routing to determine if Authorization has run
        private const string AuthorizationMiddlewareInvokedWithEndpointKey = "__AuthorizationMiddlewareWithEndpointInvoked";
        private static readonly object AuthorizationMiddlewareWithEndpointInvokedValue = new object();

        private readonly RequestDelegate _next;
        private readonly AuthenticationPeekOptions _options;

        public AuthenticationPeekMiddleware(RequestDelegate next, IOptions<AuthenticationPeekOptions> options)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.User.Identity.IsAuthenticated)
            {
                context.Response.Headers.Add("X-AuthExpSec", _options.CookieAuthExpirationSeconds);
            }

            await _next(context);
        }
    }
}
