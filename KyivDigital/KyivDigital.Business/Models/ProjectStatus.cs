using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ProjectStatus
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}