using Newtonsoft.Json;

namespace Organization.Client.Models
{
    public class BusinessUnitModel
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("index")] public int Index { get; set; }

        [JsonProperty("name")] public string Name { get; set; } = string.Empty;

        [JsonProperty("companyFk")] public long CompanyFk { get; set; }
        [JsonProperty("company")] public CompanyModel Company { get; set; }
    }
}