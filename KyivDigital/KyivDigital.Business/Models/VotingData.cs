using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class VotingData
    {
        [JsonPropertyName("icon")]
        public List<VoteButton> Buttons { get; set; }
        [JsonPropertyName("sub_title")]
        public string SubTitle { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
