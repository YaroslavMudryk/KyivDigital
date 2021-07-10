using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class MonthlyTicketPurchase
    {
        [JsonPropertyName("available_month")]
        public int AvailableMonth { get; set; }
        [JsonPropertyName("half_a_month")]
        public bool HalfAMonth { get; set; }
    }
}