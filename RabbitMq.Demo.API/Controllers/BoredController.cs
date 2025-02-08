using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMq.Demo.Business.Abstractions;
using RabbitMq.Shared.Constants;

namespace RabbitMq.Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoredController : ControllerBase<IBoredBusiness>
    {
        //https://www.boredapi.com/api/activity
        public BoredController(IBoredBusiness business) : base(business)
        {

        }
        [HttpGet("/exchange-topic")]
        public async Task<IActionResult> GetTopic()
        {
            await _business.GetAndPublishMessage();
            return Ok();
        }
        [HttpGet("/exchange-direct")]
        public async Task<IActionResult> GetDirect()
        {
            await _business.GetAndPublishMessage(ExchangeName.Direct);
            return Ok();
        }
        [HttpGet("/exchange-fanout")]
        public async Task<IActionResult> GetFanout()
        {
            await _business.GetAndPublishMessage(ExchangeName.Fanout);
            return Ok();
        }
    }
}
