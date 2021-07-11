using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ParkingSubscriptionsResponse
    {
        [JsonPropertyName("tickets")]
        public Tickets tickets { get; set; }
    }
}
