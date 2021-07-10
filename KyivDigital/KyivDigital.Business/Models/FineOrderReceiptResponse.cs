using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class FineOrderReceiptResponse
    {
        [JsonPropertyName("order_id")]
        public long OrderId { get; set; }
        [JsonPropertyName("receipt_url")]
        public string ReceiptUrl { get; set; }
        [JsonPropertyName("suggest_email")]
        public string SuggestEmail { get; set; }
    }
}