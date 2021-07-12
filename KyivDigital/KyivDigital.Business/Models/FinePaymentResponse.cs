using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FinePaymentResponse
    {
        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }
        [JsonPropertyName("fee_percent")]
        public double FeePercent { get; set; }
        [JsonPropertyName("penalty")]
        public FinePenalty Penalty { get; set; }
    }
}