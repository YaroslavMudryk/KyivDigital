using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ProjectInfo
    {
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}