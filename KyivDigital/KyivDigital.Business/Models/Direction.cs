using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Direction
    {
        [JsonPropertyName("departures")]
        public List<long> Departures { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("path")]
        public List<Path> Path { get; set; }
        [JsonPropertyName("stops")]
        public List<TransportStop> Stops { get; set; }
    }
}
