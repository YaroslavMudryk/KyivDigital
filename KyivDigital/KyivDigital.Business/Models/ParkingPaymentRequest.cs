using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ParkingPaymentRequest
    {
        [JsonPropertyName("car")]
        public CarParkingRequest Car { get; set; }
        [JsonPropertyName("car_id")]
        public long CarId { get; set; }
        [JsonPropertyName("card_id")]
        public long CardId { get; set; }
        [JsonPropertyName("google_token")]
        public string GoogleToken { get; set; }
        [JsonPropertyName("order_token")]
        public string OrderToken { get; set; }
        [JsonPropertyName("ticket_month")]
        public int TicketMonth { get; set; }
        [JsonPropertyName("total_sum")]
        public int TotalSum { get; set; }
        [JsonPropertyName("uniq_id")]
        public string UniqId { get; set; }
        [JsonPropertyName("zone")]
        public int Zone { get; set; }
    }
}
