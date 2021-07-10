using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FeedCongratulationResponse
    {
        [JsonPropertyName("content_description")]
        public string ContentDescription { get; set; }
        [JsonPropertyName("content_title")]
        public string ContentTitle { get; set; }
        [JsonPropertyName("feed_item")]
        public FeedItemModel FeedItem { get; set; }
    }
}