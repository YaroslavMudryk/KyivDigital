using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ParkingZonesResponse
    {
        [JsonPropertyName("zones")]
        public Dictionary<string, List<List<double>>> Zones { get; set; }
    }
}
