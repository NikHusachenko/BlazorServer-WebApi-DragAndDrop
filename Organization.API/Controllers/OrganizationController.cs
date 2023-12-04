using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Organization.Services.OrganizationServices;
using Organization.Services.OrganizationServices.Models;

namespace Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        [Route("/Organizations")]
        public async Task<IActionResult> Organizations()
        {
            var organization = await _organizationService.GetOrganizations();
            return Ok(JsonConvert.SerializeObject(organization, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            }));
        }
    }
}