using Microsoft.AspNetCore.Mvc;
using Organization.Services.CompanyServices;
using Organization.Services.CompanyServices.Models;

namespace Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody]UpdateCompanyHttpPostModel vm)
        {
            var response = await _companyService.Update(vm);
            if (response.IsError)
            {
                return BadRequest(new { responseMessage = response.ErrorMessage });
            }
            return Ok(new { success = true });
        }
    }
}