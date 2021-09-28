using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class TransportStop
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("isSaveSearch")]
        public bool IsSaveSearch { get; set; }
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        [JsonPropertyName("lng")]
        public double Lng { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("positionType")]
        public RouteStopType PositionType { get; set; }
        [JsonPropertyName("routes")]
        public List<TransportRoute> Routes { get; set; }
        [JsonPropertyName("transfers")]
        public List<Transfer> Transfers { get; set; }
        [JsonPropertyName("type")]
        public TransportRouteType Type { get; set; }
    }
}