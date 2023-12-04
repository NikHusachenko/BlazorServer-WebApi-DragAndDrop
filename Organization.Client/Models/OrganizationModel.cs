using System.Text.Json.Serialization;

namespace Organization.Client.Models
{
    public class OrganizationModel
    {
        [JsonPropertyName("id")] public long Id { get; set; }

        [JsonPropertyName("index")] public int Index { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

        [JsonPropertyName("companies")] public List<CompanyModel> Companies { get; set; }

        public OrganizationModel()
        {
            Companies = new List<CompanyModel>();
        }
    }
}