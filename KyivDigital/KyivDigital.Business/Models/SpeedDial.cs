using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class SpeedDial
    {
        [JsonPropertyName("firebase_type")]
        public string FirebaseType { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("payload")]
        public Payload Payload { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
