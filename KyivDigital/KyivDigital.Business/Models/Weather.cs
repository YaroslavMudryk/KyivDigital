using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Weather
    {
        [JsonPropertyName("condition")]
        public int Condition { get; set; }
        [JsonPropertyName("temp")]
        public int Temp { get; set; }
    }
}
