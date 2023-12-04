using Organization.DataAccess;
using Organization.Database.Entities;
using Organization.Services.OrganizationServices.Models;

namespace Organization.Services.OrganizationServices
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IGenericRepository<OrganizationEntity> _repository;

        public OrganizationService(IGenericRepository<OrganizationEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<OrganizationEntity>> GetOrganizations() 
            => (await _repository.GetAll()).ToList();
    }
}