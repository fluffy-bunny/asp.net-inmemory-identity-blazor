using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace InMemoryIdentityApp.Extensions
{
    public static class GraphEndpointMiddlewareExtensions
    {
        public static IEndpointConventionBuilder MapGraphVisualisation(
            this IEndpointRouteBuilder endpoints, string pattern)
        {
            var pipeline = endpoints
                .CreateApplicationBuilder()
                .UseMiddleware<GraphEndpointMiddleware>()
                .Build();

            return endpoints.Map(pattern, pipeline).WithDisplayName("Endpoint Graph");
        }
    }
}
