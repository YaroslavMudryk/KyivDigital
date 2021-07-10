using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class HourlyParkingStartRequest
    {
        [JsonPropertyName("car")]
        public Car Car { get; set; }
        [JsonPropertyName("car_id")]
        public long CarId { get; set; }
        [JsonPropertyName("place_id")]
        public string PlaceId { get; set; }
    }
}