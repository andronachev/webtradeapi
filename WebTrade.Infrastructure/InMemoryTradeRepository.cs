using System;
using System.Collections.Generic;
using System.Linq;
using WebTrade.Core;
using WebTrade.Core.Interfaces;
using WebTrade.Core.Model;

namespace WebTrade.Infrastructure
{
    public class InMemoryTradeRepository : ITradeRepository
    {
        private static List<Trade> _trades = new List<Trade>()
        {
            new Trade(){ Id=Guid.Parse("663bcc00-60bd-4a35-a3bf-83fbcdebe0ac"), BuyerId = Guid.Parse("06698b1c-254c-4cd4-aaa4-a22859136ed1"), BuyerName = "John", SecurityCode = "MSFT", SecurityId = Guid.Parse("7469186f-a6d0-498c-8726-0e7dd794d703"), TradeDate = new DateTime(2021,8,10), TradePrice = 10, TradeQuantity = 2  },
            new Trade(){ Id=Guid.Parse("e59f824c-7ef6-41ed-b746-ddae19b0ab1c"), BuyerId = Guid.Parse("06698b1c-254c-4cd4-aaa4-a22859136ed1"), BuyerName = "John", SecurityCode = "MSFT", SecurityId = Guid.Parse("7469186f-a6d0-498c-8726-0e7dd794d703"), TradeDate = new DateTime(2021,8,10), TradePrice = 10, TradeQuantity = 3  },
            new Trade(){ Id=Guid.Parse("148a919b-8eb3-45f6-8d4e-105a56c6a50a"), BuyerId = Guid.Parse("06698b1c-254c-4cd4-aaa4-a22859136ed1"), BuyerName = "John", SecurityCode = "AAPL", SecurityId = Guid.Parse("00c925f4-b56c-4358-a08c-8ab3be24e650"), TradeDate = new DateTime(2021,8,10), TradePrice = 10, TradeQuantity = 4  },
            new Trade(){ Id=Guid.Parse("5369c014-2c8b-43b0-a353-aa58821c5214"), BuyerId = Guid.Parse("a0325655-eb61-4e89-b9a2-c7b886c649ed"), BuyerName = "Alice", SecurityCode = "AAPL", SecurityId = Guid.Parse("00c925f4-b56c-4358-a08c-8ab3be24e650"), TradeDate = new DateTime(2021,8,10), TradePrice = 12, TradeQuantity = 5  }
        };

        public void DeleteTrades(Guid[] tradeIds)
        {
            _trades.RemoveAll(t => tradeIds.Contains(t.Id));
        }

        public Trade[] GetAllTrades()
        {
            return _trades.ToArray();
        }

        public Trade[] GetAllTrades(Guid buyerId)
        {
            return _trades.Where(t => t.BuyerId == buyerId).ToArray();
        }

        public void InsertTrade(Trade trade)
        {
            _trades.Add(trade);
        }
    }
}
