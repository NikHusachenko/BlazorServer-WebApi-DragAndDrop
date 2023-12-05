namespace Organization.Services.BusinessUnitServices.Models
{
    public class UpdateManyBusinessUnitHttpPostModel
    {
        public List<UpdateBusinessUnitHttpPostModel> BusinessUnits { get; set; }

        public UpdateManyBusinessUnitHttpPostModel()
        {
            BusinessUnits = new List<UpdateBusinessUnitHttpPostModel>();
        }
    }
}