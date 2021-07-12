using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class GetEvacuationPaymentResponse
    {
        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }
        [JsonPropertyName("evacuation_issued_at")]
        public long EvacuationIssuedAt { get; set; }
        [JsonPropertyName("fee_percent")]
        public double FeePercent { get; set; }
        [JsonPropertyName("paid_to")]
        public long PaidTo { get; set; }
        [JsonPropertyName("penalty_items")]
        public List<PenaltyItem> PenaltyItems { get; set; }
        [JsonPropertyName("storing_extra_days_price")]
        public int StoringExtraDaysPrice { get; set; }
        [JsonPropertyName("storing_n_days")]
        public int StoringNDays { get; set; }
        [JsonPropertyName("storing_n_price")]
        public int StoringNPrice { get; set; }
    }
}
