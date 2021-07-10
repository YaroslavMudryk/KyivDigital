using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class OrderIdResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("meta")]
        public FineOrderReceiptResponse Meta { get; set; }
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}