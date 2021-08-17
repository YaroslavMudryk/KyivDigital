using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class PublicBudgetProject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("budget")]
        public int Budget { get; set; }
        [JsonPropertyName("category")]
        public PublicBudgetProjectCategory Category { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("status")]
        public ProjectStatus Status { get; set; }
        [JsonPropertyName("voted")]
        public bool IsVoted { get; set; }
        [JsonPropertyName("votes")]
        public int Votes { get; set; }
    }
}
