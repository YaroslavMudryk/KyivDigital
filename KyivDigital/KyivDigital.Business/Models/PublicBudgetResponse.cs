using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class PublicBudgetResponse
    {
        [JsonPropertyName("faq_category_id")]
        public long FaqCategoryId { get; set; }
        [JsonPropertyName("filters")]
        public ProjectFilter Filters { get; set; }
        [JsonPropertyName("list_sub_title")]
        public string ListSubTitle { get; set; }
        [JsonPropertyName("listTitle")]
        public string ListTitle { get; set; }
        [JsonPropertyName("notification")]
        public Notification Notification { get; set; }
        [JsonPropertyName("projects")]
        public PublicBudgetProjects Projects { get; set; }
        [JsonPropertyName("votes_info")]
        public string VotesInfo { get; set; }
    }
}
