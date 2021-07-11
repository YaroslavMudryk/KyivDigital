using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class CarParkingRequest
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("usual_format")]
        public bool IsUsualFormat { get; set; }
    }
}
