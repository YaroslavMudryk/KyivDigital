using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class EvacuationStatus
    {
        [JsonPropertyName("can_confirm")]
        public bool CanConfirm { get; set; }
        [JsonPropertyName("car")]
        public CarModel Car { get; set; }
        [JsonPropertyName("steps")]
        public List<EvacuationStep> Steps { get; set; }
    }
}
