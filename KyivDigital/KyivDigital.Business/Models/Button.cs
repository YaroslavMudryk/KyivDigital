using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Button
    {
        [JsonPropertyName("caption")]
        public string Caption { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
