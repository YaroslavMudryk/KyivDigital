using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class PagedFeedResponse
    {
        [JsonPropertyName("feed")]
        public FeedData Feed { get; set; }
    }
}