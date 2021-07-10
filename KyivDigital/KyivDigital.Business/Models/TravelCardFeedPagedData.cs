using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class TravelCardFeedPagedData
    {
        [JsonPropertyName("data")]
        public List<TravelCardFeedModel> Data { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}
