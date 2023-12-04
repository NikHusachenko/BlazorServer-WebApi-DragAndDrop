using Newtonsoft.Json;

namespace Organization.Client.Models
{
    public class CompanyModel
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("index")] public int Index { get; set; }
        [JsonProperty("name")] public string Name { get; set; } = string.Empty;

        [JsonProperty("organizationFk")] public long OrganizationFk { get; set; }
        [JsonProperty("organization")] public OrganizationModel Organization { get; set; }

        [JsonProperty("businessUnits")] public List<BusinessUnitModel> BusinessUnits { get; set; }

        public CompanyModel()
        {
            BusinessUnits = new List<BusinessUnitModel>();
        }
    }
}