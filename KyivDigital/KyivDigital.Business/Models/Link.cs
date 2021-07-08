using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Link
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}