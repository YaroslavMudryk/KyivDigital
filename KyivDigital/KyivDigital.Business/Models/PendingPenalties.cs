using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class PendingPenalties
    {
        [JsonPropertyName("car")]
        public CarModel Car { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("discount")]
        public string Discount { get; set; }
        [JsonPropertyName("id")]
        public string Id{ get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }
        [JsonPropertyName("sum")]
        public long Sum { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}