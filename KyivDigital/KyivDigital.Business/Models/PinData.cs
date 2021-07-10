using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class PinData
    {
        [JsonPropertyName("has_pin")]
        public bool HasPin { get; set; }
    }
}