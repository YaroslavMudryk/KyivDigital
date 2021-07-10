using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TravelCardFeedModel
    {
        [JsonPropertyName("cardId")]
        public long CardId { get; set; }
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("subIcon")]
        public string SubIcon { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("uid")]
        public string Uid { get; set; }
        [JsonPropertyName("valueSum")]
        public int ValueSum { get; set; }
        [JsonPropertyName("valueText")]
        public string ValueText { get; set; }
    }
}