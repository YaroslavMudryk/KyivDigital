using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class FeedInfoModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("body")]
        public List<Body> Body { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("links")]
        public List<Link> Links { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("voted_for")]
        public int VotedFor { get; set; }
        [JsonPropertyName("voting_data")]
        public VotingData VotingData { get; set; }
        [JsonPropertyName("with_voting")]
        public bool WithVoting { get; set; }
    }
}
