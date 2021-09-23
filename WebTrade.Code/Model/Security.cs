using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTrade.Core.Model
{
    public class Security
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public decimal MarketPrice { get; set; }
    }
}
