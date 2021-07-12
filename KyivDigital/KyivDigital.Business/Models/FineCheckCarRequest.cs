using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FineCheckCarRequest
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("save")]
        public bool IsSave { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("usual_format")]
        public bool IsUsualFormat { get; set; }
    }
}