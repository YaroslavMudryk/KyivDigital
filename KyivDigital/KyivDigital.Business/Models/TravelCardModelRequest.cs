using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TravelCardModelRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("pin")]
        public string Pin { get; set; }
    }
}