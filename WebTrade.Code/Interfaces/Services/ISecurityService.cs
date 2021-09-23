using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrade.Core.Model;

namespace WebTrade.Core.Interfaces.Services
{
    public interface ISecurityService
    {
        void UpdateMarketPrice(Guid securityId, decimal marketPrice);

        Security[] GetAllSecurities();
    }
}
