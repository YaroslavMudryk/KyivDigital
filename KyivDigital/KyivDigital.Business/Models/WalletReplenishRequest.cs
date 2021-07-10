using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class WalletReplenishRequest
    {
        [JsonPropertyName("card_id")]
        public long CardId { get; set; }
        [JsonPropertyName("google_token")]
        public string GoogleToken { get; set; }
        [JsonPropertyName("order_token")]
        public string OrderToken { get; set; }
        [JsonPropertyName("sum")]
        public int Sum { get; set; }
        [JsonPropertyName("uniq_id")]
        public string UniqId { get; set; }
    }
}