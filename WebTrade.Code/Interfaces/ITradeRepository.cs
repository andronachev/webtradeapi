using System;
using WebTrade.Core.Model;

namespace WebTrade.Core.Interfaces
{
    public interface ITradeRepository
    {
        Trade[] GetAllTrades();

        Trade[] GetAllTrades(Guid buyerId);

        void InsertTrade(Trade trade);

        void DeleteTrades(Guid[] tradeIds);
    }
}
