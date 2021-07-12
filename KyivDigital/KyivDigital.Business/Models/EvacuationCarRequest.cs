using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class EvacuationCarRequest
    {
        [JsonPropertyName("car_id")]
        public long CarId { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("save")]
        public bool IsSave { get; set; }
        [JsonPropertyName("usual_format")]
        public bool IsUsualFormat { get; set; }
    }
}
