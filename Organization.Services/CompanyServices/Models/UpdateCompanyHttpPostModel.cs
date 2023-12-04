namespace Organization.Services.CompanyServices.Models
{
    public class UpdateCompanyHttpPostModel
    {
        public long Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public long OrganizationFk { get; set; }
    }
}