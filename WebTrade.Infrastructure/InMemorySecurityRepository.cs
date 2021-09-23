using System;
using System.Collections.Generic;
using System.Linq;
using WebTrade.Core.Interfaces;
using WebTrade.Core.Model;

namespace WebTrade.Infrastructure
{
    public class InMemorySecurityRepository : ISecurityRepository
    {
        private static List<Security> _securities = new List<Security>
        {
            new Security()
            {
                 Id = Guid.Parse("7469186f-a6d0-498c-8726-0e7dd794d703"),
                 Code = "MSFT",
                 MarketPrice = 10
            },
            new Security()
            {
                 Id = Guid.Parse("00c925f4-b56c-4358-a08c-8ab3be24e650"),
                 Code = "AAPL",
                 MarketPrice = 12
            }
        };
        public Security[] GetAllSecurities()
        {
            return _securities.ToArray();
        }

        public Security GetSecurity(Guid securityId)
        {
            return _securities.FirstOrDefault(s => s.Id == securityId);
        }

        public void UpdateSecurityMarketPrice(Guid securityId, decimal marketPrice)
        {
            var storedSecurity = _securities.FirstOrDefault(s => s.Id == securityId);
            storedSecurity.MarketPrice = marketPrice;
        }
    }
}
