using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Body
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}