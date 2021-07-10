using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class QRPurchasedFeedResponse
    {
        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }
    }
}
