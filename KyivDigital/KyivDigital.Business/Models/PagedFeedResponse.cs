using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class PagedFeedResponse : BaseResponse
    {
        [JsonPropertyName("feed")]
        public FeedData Feed { get; set; }
    }
}