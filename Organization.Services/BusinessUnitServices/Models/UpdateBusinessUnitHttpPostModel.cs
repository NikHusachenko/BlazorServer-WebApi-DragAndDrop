namespace Organization.Services.BusinessUnitServices.Models
{
    public class UpdateBusinessUnitHttpPostModel
    {
        public long Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public long CompanyFk { get; set; }
    }
}