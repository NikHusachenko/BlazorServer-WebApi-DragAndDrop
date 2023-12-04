using Organization.Database.Entities;

namespace Organization.Services.OrganizationServices.Models
{
    public class OrganizationModel
    {
        public long Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }

        public List<CompanyEntity> Companies { get; set; }
    }
}