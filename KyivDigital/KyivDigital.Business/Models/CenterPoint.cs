using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class CenterPoint
    {
        [JsonPropertyName("ln")]
        public string Ln { get; set; }
        [JsonPropertyName("lt")]
        public string Lt { get; set; }
    }
}