using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class EvacuationCarStatus
    {
        [JsonPropertyName("evacuated_by")]
        public int EvacuatedBy { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
