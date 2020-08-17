using Microsoft.Extensions.DependencyInjection;
using StockTicker.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientSideAuth.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRandomStockTicker(this IServiceCollection services)
        {
            services.AddSingleton<IStockTickerService, RandomStockTicker>();

            return services;
        }
    }
}
