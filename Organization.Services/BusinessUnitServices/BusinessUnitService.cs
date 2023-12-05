using Organization.DataAccess;
using Organization.Database.Entities;
using Organization.Services.BusinessUnitServices.Models;
using Organization.Services.Response;

namespace Organization.Services.BusinessUnitServices
{
    public class BusinessUnitService : IBusinessUntiService
    {
        private readonly IGenericRepository<BusinessUnitEntity> _genericRepository;

        public BusinessUnitService(IGenericRepository<BusinessUnitEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<ResponseService> Update(UpdateBusinessUnitHttpPostModel vm)
        {
            BusinessUnitEntity dbRecord = await _genericRepository.Find(vm.Id);
            if (dbRecord == null)
            {
                return ResponseService.Error("BusinessUnit not found");
            }

            dbRecord.Index = vm.Index;
            dbRecord.Name = vm.Name;
            dbRecord.CompanyFk = vm.CompanyFk;

            return await Update(dbRecord);
        }

        public async Task<ResponseService> UpdateMany(UpdateManyBusinessUnitHttpPostModel vm)
        {
            foreach (var model in vm.BusinessUnits)
            {
                var response = await Update(model);
                if (response.IsError)
                {
                    return response;
                }
            }
            return ResponseService.Ok();
        }

        private async Task<ResponseService> Update(BusinessUnitEntity entity)
        {
            try
            {
                await _genericRepository.Update(entity);
            }
            catch (Exception ex)
            {
                return ResponseService.Error("Can't update BusinessUnit");
            }
            return ResponseService.Ok();
        }
    }
}