using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class CarUpdateRequest
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("main")]
        public bool IsMain { get; set; }
    }
}