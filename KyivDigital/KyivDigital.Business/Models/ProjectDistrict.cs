using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ProjectDistrict
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("isSelected")]
        public bool IsSelected { get; set; }
    }
}
