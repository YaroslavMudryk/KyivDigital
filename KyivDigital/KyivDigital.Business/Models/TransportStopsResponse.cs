using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TransportStopsResponse
    {
        [JsonPropertyName("list")]
        public List<TransportStop> Stops { get; set; }
        [JsonPropertyName("list_hash")]
        public string StopsHash { get; set; }
    }
}