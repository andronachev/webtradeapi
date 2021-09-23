using System;
using System.ComponentModel.DataAnnotations;
using WebTrade.Core;
using WebTrade.Core.Interfaces;
using WebTrade.Core.Interfaces.Services;

namespace WebTrade.Services
{
    public class TradeService : ITradeService
    {
        private ITradeRepository _tradeRepository;
        private ISecurityRepository _securityRepository;
        private IBuyerRepository _buyerRepository;

        public TradeService(ITradeRepository tradeRepository, ISecurityRepository securityRepository, IBuyerRepository buyerRepository)
        {
            _tradeRepository = tradeRepository;
            _securityRepository = securityRepository;
            _buyerRepository = buyerRepository;
        }

        public void DeleteTrades(Guid[] tradeIds)
        {
            _tradeRepository.DeleteTrades(tradeIds);
        }

        public Trade[] GetAllTrades()
        {
            return _tradeRepository.GetAllTrades();
        }

        public Trade[] GetAllTrades(Guid buyerId)
        {
            return _tradeRepository.GetAllTrades(buyerId);
        }

        public void InsertTrade(Trade trade)
        {
            if(trade == null)
            {
                throw new ValidationException("Trade is null");
            }
            var security = _securityRepository.GetSecurity(trade.SecurityId);
            if(security == null)
            {
                throw new ValidationException("Security not found");
            }

            var buyer = _buyerRepository.GetBuyer(trade.BuyerId);
            if (buyer == null)
            {
                throw new ValidationException("Buyer not found");
            }

            if (trade.TradePrice <= 0)
            {
                throw new ValidationException("Trade price cannot be <= 0");
            }
            if (trade.TradeQuantity <= 0)
            {
                throw new ValidationException("Trade quantity cannot be <= 0");
            }

            _tradeRepository.InsertTrade(trade);
        }
    }
}
