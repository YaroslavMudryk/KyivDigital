using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Directions
    {
        [JsonPropertyName("backward")]
        public Direction Backward { get; set; }
        [JsonPropertyName("forward")]
        public Direction Forward { get; set; }
    }
}
