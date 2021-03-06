using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DevExpress.Blazor;
using ClientSideAuth.Extensions;
using BlazorAppRealTime.Services;
using Blazored.LocalStorage;
using OAuth2.TokenManagement.Client.Extensions;

namespace BlazorAppRealTime
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddOptions();
            builder.AddClientSideAuth();
            builder.AddClientSideAuthTimerService();
            builder.AddManagedTokenServices();
            builder.Services.AddTransient<FetchWeatherForecastService>();
            builder.Services.AddTransient<FetchAuthStatusService>();
            builder.Services.AddDevExpressBlazor((options) => options.SizeMode = SizeMode.Medium);
            builder.Services.AddBlazoredLocalStorage(config =>
                config.JsonSerializerOptions.WriteIndented = true);
            await builder.Build().RunAsync();
        }
    }
}
