using System;
using System.ComponentModel.DataAnnotations;
using WebTrade.Core.Interfaces;
using WebTrade.Core.Interfaces.Services;

namespace WebTrade.Services
{
    public class SecurityService : ISecurityService
    {
        private ISecurityRepository _securityRepository;
        public SecurityService(ISecurityRepository securotyRepository)
        {
            _securityRepository = securotyRepository;
        }

        public Core.Model.Security[] GetAllSecurities()
        {
            return _securityRepository.GetAllSecurities();
        }

        public void UpdateMarketPrice(Guid securityId, decimal marketPrice)
        {
            var security = _securityRepository.GetSecurity(securityId);
            if (security == null)
            {
                throw new ValidationException("Security not found");
            }
            if(marketPrice < 0)
            {
                throw new ValidationException("Market price cannot be < 0");
            }

            _securityRepository.UpdateSecurityMarketPrice(securityId, marketPrice);
        }
    }
}
