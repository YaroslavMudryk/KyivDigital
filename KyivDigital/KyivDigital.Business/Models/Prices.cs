using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Prices
    {
        [JsonPropertyName("copy")]
        public int Copy { get; set; }
        [JsonPropertyName("zone_1")]
        public int Zone1 { get; set; }
        [JsonPropertyName("zone_2")]
        public int Zone2 { get; set; }
        [JsonPropertyName("zone_3")]
        public int Zone3 { get; set; }
    }
}
