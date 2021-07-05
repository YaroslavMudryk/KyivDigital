using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Payload
    {
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
        [JsonPropertyName("lasts_for")]
        public long LastsFor { get; set; }
        [JsonPropertyName("qrs_count")]
        public int QrsCount { get; set; }
    }
}
