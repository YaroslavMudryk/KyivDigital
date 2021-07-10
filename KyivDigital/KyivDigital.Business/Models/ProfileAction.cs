using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class ProfileAction
    {
        [JsonPropertyName("button")]
        public Button Button { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}