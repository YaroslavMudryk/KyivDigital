using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FeedEvacuationResponse
    {
        [JsonPropertyName("car")]
        public CarModel Car { get; set; }
        [JsonPropertyName("completed")]
        public bool IsCompleted { get; set; }
        [JsonPropertyName("evidence_file")]
        public string EvidenceFile { get; set; }
        [JsonPropertyName("feed_item")]
        public FeedItemModel FeedItem { get; set; }
        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }
    }
}