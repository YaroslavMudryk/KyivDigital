using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TravelCardHistoryModel
    {
        [JsonPropertyName("cardId")]
        public long CardId { get; set; }
        [JsonPropertyName("issued_at")]
        public long IssuedAt { get; set; }
        [JsonPropertyName("stop_name")]
        public string StopName { get; set; }
        [JsonPropertyName("transport_type")]
        public string TransportType { get; set; }
        [JsonPropertyName("uid")]
        public long Uid { get; set; }
    }
}