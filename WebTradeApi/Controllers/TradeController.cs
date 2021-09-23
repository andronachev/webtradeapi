using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTrade.Core;
using WebTrade.Core.Interfaces.Services;

namespace WebTradeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ILogger<TradeController> _logger;
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService, ILogger<TradeController> logger)
        {
            _logger = logger;
            _tradeService = tradeService;
        }

        [HttpGet]
        public IEnumerable<Trade> Get()
        {
            var trades = _tradeService.GetAllTrades();
            return trades;
        }

        [HttpPost]
        public ActionResult Post(Trade trade)
        {
            _tradeService.InsertTrade(trade);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteTrades(Guid[] tradeIds)
        {
            _tradeService.DeleteTrades(tradeIds);
            return Ok();
        }
    }
}
