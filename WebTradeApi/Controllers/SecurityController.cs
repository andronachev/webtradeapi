using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTrade.Core;
using WebTrade.Core.Interfaces.Services;
using WebTrade.Core.Model;

namespace WebTradeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService, ILogger<SecurityController> logger)
        {
            _logger = logger;
            _securityService = securityService;
        }

        [HttpGet]
        public IEnumerable<Security> Get()
        {
            var securities = _securityService.GetAllSecurities();
            return securities;
        }

        [HttpPost]
        public ActionResult Post(Trade trade)
        {
            return Ok();
        }
    }
}
