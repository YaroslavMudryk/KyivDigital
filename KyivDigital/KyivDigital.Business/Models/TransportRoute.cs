using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class TransportRoute
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("is_save_search")]
        public bool IsSaveSearch { get; set; }
        [JsonPropertyName("type")]
        public TransportRouteType Type { get; set; }
    }
}
