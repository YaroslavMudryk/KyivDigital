using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class MasterpassResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}