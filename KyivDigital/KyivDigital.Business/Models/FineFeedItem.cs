using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FineFeedItem
    {
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("sub_icon")]
        public string SubIcon { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("value_sum")]
        public int ValueSum { get; set; }
        [JsonPropertyName("value_text")]
        public string ValueText { get; set; }
    }
}