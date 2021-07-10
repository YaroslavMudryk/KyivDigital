using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Car
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("usual_format")]
        public bool UsualFormat { get; set; }
    }
}