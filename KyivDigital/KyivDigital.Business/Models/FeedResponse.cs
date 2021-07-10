using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class FeedResponse
    {
        [JsonPropertyName("feed")]
        public List<FeedItemModel> Feed { get; set; }
    }
}
