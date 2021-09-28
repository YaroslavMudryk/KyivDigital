using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class TransportRoutesResponse
    {
        [JsonPropertyName("routes")]
        public List<TransportRoute> Routes { get; set; }
        [JsonPropertyName("stops")]
        public List<TransportStop> Stops { get; set; }
    }
}