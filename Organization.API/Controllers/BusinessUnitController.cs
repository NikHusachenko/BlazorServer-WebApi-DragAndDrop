using Microsoft.AspNetCore.Mvc;
using Organization.Services.BusinessUnitServices;
using Organization.Services.BusinessUnitServices.Models;

namespace Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly IBusinessUntiService _usinessUntiService;

        public BusinessUnitController(IBusinessUntiService usinessUntiService)
        {
            _usinessUntiService = usinessUntiService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateBusinessUnitHttpPostModel vm)
        {
            var response = await _usinessUntiService.Update(vm);
            if (response.IsError)
            {
                return BadRequest(new { responseMessage = response.ErrorMessage });
            }
            return Ok(new { success = true });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateMany([FromBody]UpdateManyBusinessUnitHttpPostModel vm)
        {
            var response = await _usinessUntiService.UpdateMany(vm);
            if (response.IsError)
            {
                return BadRequest(new { responseMessage = response.ErrorMessage });
            }
            return Ok(new { success = true });
        }
    }
}