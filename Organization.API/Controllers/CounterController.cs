using Microsoft.AspNetCore.Mvc;

namespace Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private static int _counter;

        static CounterController()
        {
            _counter = 0;
        }

        [HttpGet]
        [Route("/Counter")]
        public async Task<IActionResult> IncrementCounter()
        {
            return Ok(++_counter);
        }
    }
}