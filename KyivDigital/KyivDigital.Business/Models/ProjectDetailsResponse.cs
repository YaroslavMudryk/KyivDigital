using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ProjectDetailsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("app_link")]
        public string AppLink { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("faq_category_id")]
        public long FaqCategoryId { get; set; }
        [JsonPropertyName("info_items")]
        public List<ProjectInfo> InfoItems { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("photos")]
        public List<string> Photos { get; set; }
        [JsonPropertyName("problem")]
        public string Problem { get; set; }
        [JsonPropertyName("proposal")]
        public string Proposal { get; set; }
        [JsonPropertyName("share_content")]
        public string ShareContent { get; set; }
        [JsonPropertyName("status")]
        public ProjectStatus Status { get; set; }
        [JsonPropertyName("voted_for_category")]
        public bool VotedForCategory { get; set; }
        [JsonPropertyName("votes")]
        public int Votes { get; set; }
        [JsonPropertyName("voting")]
        public ProjectVoting Voting { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}