using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Links
    {
        [JsonPropertyName("next")]
        public string Next { get; set; }
        [JsonPropertyName("previous")]
        public string Previous { get; set; }
    }
}
