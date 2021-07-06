using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class FeedData
    {
        [JsonPropertyName("data")]
        public List<FeedItemModel> Data { get; set; }
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}
