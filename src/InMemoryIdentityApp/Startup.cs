using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using InMemoryIdentityApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using InMemoryIdentityApp.Extensions;
using Microsoft.AspNetCore.Identity.Extensions;
using Microsoft.Extensions.Logging;
using Serilog.Enrichers.Extensions;
using CorrelationId.DependencyInjection;
using CorrelationId;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.ResponseCompression;
using InMemoryIdentityApp.Hubs;
using ClientSideAuth.Extensions;
using Microsoft.AspNetCore.Routing;
using InMemoryIdentityApp.Authorization;

namespace InMemoryIdentityApp
{

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public string CookieAuthExpirationSeconds { get; }

        private IHostEnvironment _hostingEnvironment; 
        private ILogger _logger;
        private Exception _deferedException;

        public Startup(IConfiguration configuration,
             IHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _logger = new LoggerBuffered(LogLevel.Debug);
            _logger.LogInformation($"Create Startup {hostingEnvironment.ApplicationName} - {hostingEnvironment.EnvironmentName}");
            CookieAuthExpirationSeconds =  Configuration["CookieAuthExpirationSeconds"];
           
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {

                services.Configure<AuthenticationPeekOptions>((options) =>
                {
                    options.CookieAuthExpirationSeconds = CookieAuthExpirationSeconds;
                });
               services.AddCors(options => options.AddPolicy("CorsPolicy",
                  builder =>
                  {
                      builder.AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowAnyOrigin();
                  }));
                services.AddRandomStockTicker();
                services.AddDefaultCorrelationId();
                services.AddEnrichers();
                services.Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

                services.AddInMemoryIdentity<ApplicationUser, ApplicationRole>().AddDefaultTokenProviders();


                services.ConfigureApplicationCookie(options =>
                {
                    options.Cookie.Name = $"{Configuration["applicationName"]}.AspNetCore.Identity.Application";
                    options.LoginPath = $"/Identity/Account/Login";
                    options.LogoutPath = $"/Identity/Account/Logout";
                    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnRedirectToLogin = (ctx) =>
                        {
                            if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == StatusCodes.Status200OK)
                            {
                                ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            }

                            return Task.CompletedTask;
                        },
                        OnRedirectToAccessDenied = (ctx) =>
                        {
                            if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == StatusCodes.Status200OK)
                            {
                                ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
                            }

                            return Task.CompletedTask;
                        }
                    };
                    var authExpirationSeconds = Convert.ToInt32(CookieAuthExpirationSeconds);
                    options.ExpireTimeSpan = new TimeSpan(0, 0, authExpirationSeconds);
                });
                services.AddAuthentication<ApplicationUser>(Configuration);

                 

                services.AddControllers();
                services.AddRazorPages();
                services.AddSignalR();
                services.AddResponseCompression(opts =>
                {
                    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                        new[] { "application/octet-stream" });
                });

                // Adds a default in-memory implementation of IDistributedCache.
                services.AddDistributedMemoryCache();

                services.AddSession(options =>
                {
                    options.Cookie.IsEssential = true;
                    options.Cookie.Name = $"{Configuration["applicationName"]}.Session";
                    // Set a short timeout for easy testing.
                    options.IdleTimeout = TimeSpan.FromSeconds(3600);
                    options.Cookie.HttpOnly = true;
                });
            }
            catch (Exception ex)
            {
                _deferedException = ex;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            ILogger<Startup> logger)
        {
            if (_logger is LoggerBuffered)
            {
                (_logger as LoggerBuffered).CopyToLogger(logger);
            }
            _logger = logger;
            _logger.LogInformation("Configure");
            if (_deferedException != null)
            {
                _logger.LogError(_deferedException.Message);
                throw _deferedException;
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            if (env.IsDevelopment())
            {
                app.Map("/graph", branch =>
                    branch.UseMiddleware<GraphEndpointMiddleware>());
            }

            app.MapWhen(ctx => {
                return ctx.Request.Path.StartsWithSegments("/BlazorHost/BlazorAppRealTime");
            }, config => {
                AddBlazorPathHosted(config, "BlazorHost", "BlazorHost/BlazorAppRealTime");
            });
            app.MapWhen(ctx => {
                return ctx.Request.Path.StartsWithSegments("/BlazorAppRealTime");
            }, config => {
                AddBlazorPath(config, "BlazorAppRealTime");
            });
            app.MapWhen(ctx => {
                return ctx.Request.Path.StartsWithSegments("/BlazorApp1");
            }, config => {
                AddBlazorPath(config, "BlazorApp1");
            });
            app.MapWhen(ctx => {
                return ctx.Request.Path.StartsWithSegments("/BlazorApp2");
            }, config => {
                AddBlazorPath(config, "BlazorApp2");
            });
            app.MapWhen(ctx => {
                if (
                ctx.Request.Path.StartsWithSegments("/BlazorHost/") ||
                ctx.Request.Path.StartsWithSegments("/BlazorApp1") ||
                ctx.Request.Path.StartsWithSegments("/BlazorApp2") ||
                ctx.Request.Path.StartsWithSegments("/BlazorAppRealTime"))
                    return false;
                return true;
            }, config => {

                config.UseStaticFiles();
                config.UseCorrelationId();
                config.UseCookiePolicy();
                config.UseCors("CorsPolicy");

                config.UseRouting();
                UseAuthMiddleware(config);
                config.UseSession();
                config.UseEndpoints(endpoints =>
                {
                    MapBasicEndpoints(endpoints);

                    endpoints.MapHub<StockTickerHub>("/stock-ticker");
                });
            });

        }
        private void UseAuthMiddleware(IApplicationBuilder builder)
        {
            builder.UseAuthentication();
            builder.UseAuthorization();
            builder.UseMiddleware<AuthenticationPeekMiddleware>();
        }
        void AddBlazorPathHosted(IApplicationBuilder builder, string page, string pattern)
        {
            builder.UseBlazorFrameworkFiles($"/{pattern}");
            builder.UseStaticFiles();
            builder.UseCorrelationId();
            builder.UseCookiePolicy();
            builder.UseCors("CorsPolicy");
            //  app.UseBlazorFrameworkFiles();

            builder.UseRouting();

            UseAuthMiddleware(builder);
            builder.UseSession();
            builder.UseEndpoints(endpoints =>
            {
                MapBasicEndpoints(endpoints);
            });

        }
        void AddBlazorPath(IApplicationBuilder builder, string name)
        {
            builder.UseBlazorFrameworkFiles($"/{name}");
            builder.UseStaticFiles();
            builder.UseCorrelationId();
            builder.UseCookiePolicy();
            builder.UseCors("CorsPolicy");
            //  app.UseBlazorFrameworkFiles();

            builder.UseRouting();

            UseAuthMiddleware(builder);
            builder.UseSession();
            builder.UseEndpoints(endpoints =>
            {
                MapBasicEndpoints(endpoints);
                endpoints.MapFallbackToFile($"/{name}/{{*path:nonfile}}", $"{name}/index.html");
            });
      
        }
        private static void MapBasicEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllers();
            endpoints.MapRazorPages();
        }
    }
}
