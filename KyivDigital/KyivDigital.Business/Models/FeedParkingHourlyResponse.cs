
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FeedParkingHourlyResponse
    {
        [JsonPropertyName("feed_item")]
        public FeedItemModel FeedItem { get; set; }
        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }
    }
}