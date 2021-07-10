using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class ExpiringQRsResponse
    {
        [JsonPropertyName("feed_item")]
        public FeedItemModel FeedItem { get; set; }
        [JsonPropertyName("qrs")]
        public List<QRCodeModel> Qrs { get; set; }
    }
}