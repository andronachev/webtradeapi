using System;
using WebTrade.Core.Model;

namespace WebTrade.Core.Interfaces
{
    public interface ISecurityRepository
    {
        void UpdateSecurityMarketPrice(Guid securityId, decimal marketPrice);

        Security[] GetAllSecurities();

        Security GetSecurity(Guid securityId);
    }
}
