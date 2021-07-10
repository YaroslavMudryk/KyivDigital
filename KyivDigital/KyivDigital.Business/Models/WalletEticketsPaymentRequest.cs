using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class WalletEticketsPaymentRequest
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("uniq_id")]
        public string UniqId { get; set; }
    }
}