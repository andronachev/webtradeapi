using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTrade.Core.Model
{
    public class PortofolioListing
    {
        public Guid BuyerId { get; set; }
        public string BuyerName { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal MarketValue { get; set; }
        public decimal ProfitLoss { get; set; }
    }
}
