using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class CarRequest
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("main")]
        public bool IsMain { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("own")]
        public bool IsOwn { get; set; }
        [JsonPropertyName("usual_format")]
        public bool IsUsualFormat { get; set; }
    }
}