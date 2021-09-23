using System;

namespace WebTrade.Core
{
    public class Trade
    {
        public Guid Id { get; set; }

        public Guid SecurityId { get; set; }

        public string SecurityCode { get; set; }

        public decimal TradePrice { get; set; }

        public int TradeQuantity { get; set; }
        
        public DateTime TradeDate { get; set; }

        public Guid BuyerId { get; set; }

        public string BuyerName { get; set; }
    }
}
