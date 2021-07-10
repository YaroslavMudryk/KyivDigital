using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TravelCardUpdateRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}