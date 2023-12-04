namespace Organization.Database.Entities
{
    public class BusinessUnitEntity
    {
        public long Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; } = string.Empty;

        public long CompanyFk { get; set; }
        public CompanyEntity Company { get; set; }
    }
}