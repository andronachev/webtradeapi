using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTrade.Core.Interfaces.Services
{
    public interface ITradeService
    {
        void InsertTrade(Trade trade);

        void DeleteTrades(Guid[] tradeIds);

        Trade[] GetAllTrades();

        Trade[] GetAllTrades(Guid buyerId);
    }
}
