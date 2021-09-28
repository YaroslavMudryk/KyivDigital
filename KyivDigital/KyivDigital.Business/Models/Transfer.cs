using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Transfer
    {
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("type")]
        public long Type { get; set; }
    }
}
