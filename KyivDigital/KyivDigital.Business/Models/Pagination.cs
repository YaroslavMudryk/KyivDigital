using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Pagination
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }
        [JsonPropertyName("links")]
        public Links Links { get; set; }
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
    }
}
