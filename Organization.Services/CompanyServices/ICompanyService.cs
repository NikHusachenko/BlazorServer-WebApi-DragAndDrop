using Organization.Services.CompanyServices.Models;
using Organization.Services.Response;

namespace Organization.Services.CompanyServices
{
    public interface ICompanyService
    {
        Task<ResponseService> Update(UpdateCompanyHttpPostModel vm);
        Task<ResponseService> UpdateMany(UpdateManyCompanyHttpPostModel vm);
    }
}