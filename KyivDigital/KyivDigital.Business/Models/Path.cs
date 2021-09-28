using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Path
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }
}
