using Organization.Database.Entities;
using Organization.Services.OrganizationServices.Models;

namespace Organization.Services.OrganizationServices
{
    public interface IOrganizationService
    {
        Task<List<OrganizationEntity>> GetOrganizations();
    }
}