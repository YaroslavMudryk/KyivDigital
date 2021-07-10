using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class LikeRequest
    {
        [JsonPropertyName("like")]
        public bool Vote { get; set; }
    }
}