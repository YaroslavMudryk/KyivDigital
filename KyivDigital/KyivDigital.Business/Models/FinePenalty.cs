using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FinePenalty
    {
        [JsonPropertyName("car")]
        public CarModel Car { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("details")]
        public List<FineDetails> Details { get; set; }
        [JsonPropertyName("discount")]
        public string Discount { get; set; }
        [JsonPropertyName("has_pib")]
        public bool HasPib { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("payment_items")]
        public List<PenaltyItem> PaymentItems { get; set; }
        [JsonPropertyName("photos")]
        public List<string> Photos { get; set; }
        [JsonPropertyName("restrict_payment")]
        public bool RestrictPayment { get; set; }
        [JsonPropertyName("restrict_payment_text")]
        public string RestrictPaymentText { get; set; }
        [JsonPropertyName("sum")]
        public long Sum { get; set; }
    }
}