using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class PaymentResponse
    {
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("meta")]
        public FineOrderReceiptResponse meta { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}