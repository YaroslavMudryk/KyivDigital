using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class TravelCardReplaceModel
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("pin")]
        public string Pin { get; set; }
    }
}
