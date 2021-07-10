using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class PaymentItem
    {
        [JsonPropertyName("amount")]
        public long Amount { get; set; }
        [JsonPropertyName("description")]
        public long Description { get; set; }
    }
}