namespace Organization.Services.CompanyServices.Models
{
    public class UpdateManyCompanyHttpPostModel
    {
        public List<UpdateCompanyHttpPostModel> Companies { get; set; }

        public UpdateManyCompanyHttpPostModel()
        {
            Companies = new List<UpdateCompanyHttpPostModel>();
        }
    }
}