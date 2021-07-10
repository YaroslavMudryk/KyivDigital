using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TravelCardFeedResponse
    {
        [JsonPropertyName("card")]
        public TravelCardModel Card { get; set; }
        [JsonPropertyName("feed")]
        public List<TravelCardFeedModel> Feed { get; set; }
        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }
    }
}