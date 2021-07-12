using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FinesFeedData
    {
        [JsonPropertyName("data")]
        public List<FineFeedItem> Data { get; set; }
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}