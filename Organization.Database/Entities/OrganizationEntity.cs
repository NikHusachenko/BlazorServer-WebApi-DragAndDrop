namespace Organization.Database.Entities
{
    public class OrganizationEntity
    {
        public long Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<CompanyEntity> Companies { get; set; }

        public OrganizationEntity()
        {
            Companies = new List<CompanyEntity>();
        }
    }
}