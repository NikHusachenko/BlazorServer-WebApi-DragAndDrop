using Organization.Services.BusinessUnitServices.Models;
using Organization.Services.Response;

namespace Organization.Services.BusinessUnitServices
{
    public interface IBusinessUntiService
    {
        Task<ResponseService> Update(UpdateBusinessUnitHttpPostModel vm);
        Task<ResponseService> UpdateMany(UpdateManyBusinessUnitHttpPostModel vm);
    }
}