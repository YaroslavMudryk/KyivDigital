using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class HourlyParking
    {
        [JsonPropertyName("places")]
        public List<Place> Places { get; set; }
        [JsonPropertyName("price_info")]
        public string PriceInfo { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}