using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class GooglePayDataResponse
    {
        [JsonPropertyName("order_token")]
        public string OrderToken { get; set; }
        [JsonPropertyName("payment_items")]
        public List<PaymentItem> PaymentItems { get; set; }
        [JsonPropertyName("total_amount")]
        public long TotalAmount { get; set; }
    }
}