using BazorAuth.Shared;
using InMemoryIdentityApp.Constants;
using InMemoryIdentityApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryIdentityApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
   
    public class AuthStatusController : ControllerBase
    {

        private readonly ILogger<AuthStatusController> _logger;

        public AuthStatusController(ILogger<AuthStatusController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("ping")]
        public async Task GetPingAsync()
        {
            // simply here to generate traffic and get the headers back
        }

        [HttpGet]
        [Authorize]
        [Route("display-name")]
        public async Task<string> GetDisplayNameAsync()
        {
            var displayName = (from item in User.Claims
                               where item.Type == "display-name"
                               select item.Value).FirstOrDefault();
            return displayName;
        }
        [HttpGet]
        [Authorize]
        [Route("claims")]
        public async Task<IEnumerable<ClaimHandle>> GetClaimsAsync()
        {
            var claims = from claim in User.Claims
                         let c = new ClaimHandle
                         {
                             Type = claim.Type,
                             Value = claim.Value
                         }
                         select c;
           
            return claims;
        }
        [HttpGet]
        [Authorize]
        [Route("oidc-session-details")]
        public async Task<OpenIdConnectSessionDetails> GetOpenIdConnectSessionDetailsAsync()
        {
            OpenIdConnectSessionDetails result = HttpContext.Session.Get<OpenIdConnectSessionDetails>(Wellknown.OIDCSessionKey);
            return result;
        }
    }
}
