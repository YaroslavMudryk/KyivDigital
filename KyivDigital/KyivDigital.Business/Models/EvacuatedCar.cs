using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class EvacuatedCar
    {
        [JsonPropertyName("car")]
        public CarModel Car { get; set; }
    [JsonPropertyName("evacuation")]
        public EvacuationCarStatus Evacuation { get; set; }
    }
}
