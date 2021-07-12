using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FinesRegion
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("is_selected")]
        public bool IsSelected { get; set; }
        [JsonPropertyName("name")]
        public string RegionName { get; set; }
        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}