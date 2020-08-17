using BazorAuth.Shared;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTicker.Service
{
    public interface IStockTickerService
    {
        IStockTickerCallback Callback { get; set; }

        MarketState MarketState { get; }
        IEnumerable<Stock> GetAllStocks();

        Task OpenMarket();
        Task CloseMarket();
        Task Reset();
    }
}
