namespace Organization.Database.Entities
{
    public class CompanyEntity
    {
        public long Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; } = string.Empty;

        public long OrganizationFk { get; set; }
        public OrganizationEntity Organization { get; set; }

        public List<BusinessUnitEntity> BusinessUnits { get; set; }

        public CompanyEntity()
        {
            BusinessUnits = new List<BusinessUnitEntity>();
        }
    }
}