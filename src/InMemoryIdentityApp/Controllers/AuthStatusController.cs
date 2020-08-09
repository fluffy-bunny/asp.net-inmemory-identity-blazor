using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryIdentityApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]
    public class AuthStatusController : ControllerBase
    {

        private readonly ILogger<AuthStatusController> _logger;

        public AuthStatusController(ILogger<AuthStatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> GetAsync()
        {
            var displayName = (from item in User.Claims
                               where item.Type == "display-name"
                               select item.Value).FirstOrDefault();
            return displayName;
        }
    }
}
