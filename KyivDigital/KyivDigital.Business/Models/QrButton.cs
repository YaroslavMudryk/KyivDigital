using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class QrButton
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
