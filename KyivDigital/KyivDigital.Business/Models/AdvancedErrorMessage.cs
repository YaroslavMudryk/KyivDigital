using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class AdvancedErrorMessage
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}