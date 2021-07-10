using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Link
    {
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}