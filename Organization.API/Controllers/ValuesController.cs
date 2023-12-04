using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Organization.API.Hubs;

namespace Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHubContext<ValueHub> _hubContext;

        public ValuesController(IHubContext<ValueHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("/setvalue")]
        public async Task<IActionResult> ReceiveValue([FromBody] ValueModel vm)
        {
            await _hubContext.Clients.All.SendAsync("UpdateValue", new ValueModel()
            {
                NumberValue = new Random().Next(),
                StringValue = "New value"
            });
            return Ok();
        }
    }

    public class ValueModel
    {
        public string StringValue { get; set; }
        public int NumberValue { get; set; }
    }
}