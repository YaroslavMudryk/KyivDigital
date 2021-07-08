using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class FeedFineResponse : BaseResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("body")]
        public Body[] Body { get; set; }
        [JsonPropertyName("with_voting")]
        public bool WithVoting { get; set; }
        [JsonPropertyName("voting_data")]
        public object VotingData { get; set; }
        [JsonPropertyName("voted_for")]
        public object VotedFor { get; set; }
        [JsonPropertyName("links")]
        public Link[] Links { get; set; }
        [JsonPropertyName("feed_item")]
        public FeedItemModel FeedItem { get; set; }
    }
}