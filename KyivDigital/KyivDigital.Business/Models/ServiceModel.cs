using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ServiceModel
    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("available")]
        public bool Available { get; set; }
        [JsonPropertyName("category_Id")]
        public long CategoryId { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("service_order")]
        public int ServiceOrder { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("voted")]
        public bool IsVoted { get; set; }
        [JsonPropertyName("votes")]
        public int Votes { get; set; }
    }
}
