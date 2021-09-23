using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebTrade.Core.Interfaces;
using WebTrade.Core.Interfaces.Services;
using WebTrade.Core.Model;

namespace WebTrade.Services
{
    public class PortofolioService : IPortofolioService
    {
        private ITradeRepository _tradeRepository;
        private ISecurityRepository _securityRepository;
        private IBuyerRepository _buyerRepository;

        public PortofolioService(ITradeRepository tradeRepository, ISecurityRepository securityRepository, IBuyerRepository buyerRepository)
        {
            _tradeRepository = tradeRepository;
            _securityRepository = securityRepository;
            _buyerRepository = buyerRepository;
        }

        public PortofolioListing[] GetAllPortofolios()
        {
            List<PortofolioListing> listings = new List<PortofolioListing>();
            var buyers = _buyerRepository.GetAllBuyers();
            var securities = _securityRepository.GetAllSecurities();
            var trades = _tradeRepository.GetAllTrades();

            foreach(var buyer in buyers)
            {
                var buyerTrades = trades.Where(t => t.BuyerId == buyer.Id);
                var totalPurchaseValue = buyerTrades.Sum(t => t.TradePrice * t.TradeQuantity);
                var totalMarketValue = buyerTrades.Sum(t => securities.First(s => s.Id == t.SecurityId).MarketPrice * t.TradeQuantity);

                listings.Add(new PortofolioListing()
                {
                    BuyerId = buyer.Id,
                    BuyerName = buyer.Name,
                    MarketValue = totalMarketValue,
                    PurchaseValue = totalPurchaseValue,
                    ProfitLoss = totalMarketValue - totalPurchaseValue
                });
            }

            return listings.ToArray();
        }

    }
}
