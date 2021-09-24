using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebTrade.Core.Interfaces.Services;
using WebTrade.Core.Model;

namespace WebTradeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortofolioController : ControllerBase
    {
        private readonly ILogger<PortofolioController> _logger;
        private readonly IPortofolioService _portofolioService;

        public PortofolioController(IPortofolioService portofolioService, ILogger<PortofolioController> logger)
        {
            _logger = logger;
            _portofolioService = portofolioService;
        }

        [HttpGet]
        public IEnumerable<PortofolioListing> Get()
        {
            var portofolios = _portofolioService.GetAllPortofolios();
            return portofolios;
        }
    }
}
