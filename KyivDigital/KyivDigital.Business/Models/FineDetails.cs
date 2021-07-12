using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FineDetails
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}