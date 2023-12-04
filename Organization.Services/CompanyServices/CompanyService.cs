using Organization.DataAccess;
using Organization.Database.Entities;
using Organization.Services.CompanyServices.Models;
using Organization.Services.Response;

namespace Organization.Services.CompanyServices
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<CompanyEntity> _companyRepository;

        public CompanyService(IGenericRepository<CompanyEntity> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ResponseService> Update(UpdateCompanyHttpPostModel vm)
        {
            CompanyEntity dbRecord = await _companyRepository.Find(vm.Id);
            if (dbRecord == null)
            {
                return ResponseService.Error("Company not found");
            }

            dbRecord.Index = vm.Index;
            dbRecord.Name = vm.Name;
            dbRecord.OrganizationFk = vm.OrganizationFk;

            return await Update(dbRecord);
        }

        private async Task<ResponseService> Update(CompanyEntity entity)
        {
            try
            {
                await _companyRepository.Update(entity);
            }
            catch (Exception ex)
            {
                return ResponseService.Error("Can't update company");
            }
            return ResponseService.Ok();
        }
    }
}