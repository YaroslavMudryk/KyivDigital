using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class QrTravelPaymentRequest
    {
        [JsonPropertyName("card_id")]
        public long CardId { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("dry_run_google")]
        public bool DryRunGoogle { get; set; }
        [JsonPropertyName("google_token")]
        public string GoogleToken { get; set; }
        [JsonPropertyName("order_token")]
        public string OrderToken { get; set; }
        [JsonPropertyName("uniq_id")]
        public string UniqId { get; set; }
    }
}