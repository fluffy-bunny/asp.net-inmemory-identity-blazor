using BazorAuth.Shared;
using System.Threading.Tasks;

namespace StockTicker.Service
{
    public interface IStockTickerCallback
    {
        Task OnMarketStateChanged(MarketState state);
        Task OnMarketReset();
        Task OnStockChanged(Stock stock);
    }
}
