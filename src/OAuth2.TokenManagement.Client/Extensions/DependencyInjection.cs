using ClientSideAuth.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OAuth2.TokenManagement.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace OAuth2.TokenManagement.Client.Extensions
{

    public static class DependencyInjection
    {
        public static WebAssemblyHostBuilder AddManagedTokenServices(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<ITokenManager, TokenManager >();
            builder.Services.AddScoped<IAuthHandlerStateSink, TokenManagerAuthHandlerStateSink>();
            return builder;
        }
    }
}
