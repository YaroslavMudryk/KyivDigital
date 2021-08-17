using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Notification
    {
        [JsonPropertyName("button")]
        public string Button { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("Title")]
        public string title { get; set; }
    }
}
