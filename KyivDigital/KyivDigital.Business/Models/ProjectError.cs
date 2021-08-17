using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ProjectError
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}