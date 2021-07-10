using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TravelCardFeedPagedResponse
    {
        [JsonPropertyName("card")]
        public TravelCardModel TravelCard { get; set; }

        [JsonPropertyName("feed")]
        public TravelCardFeedPagedData Feed { get; set; }
    }
}