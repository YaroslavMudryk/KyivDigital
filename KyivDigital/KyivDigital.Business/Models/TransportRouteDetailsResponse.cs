using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class TransportRouteDetailsResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("directions")]
        public Directions Directions { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("saved")]
        public bool IsSaved { get; set; }
        [JsonPropertyName("tariff")]
        public int Tariff { get; set; }
    }
}