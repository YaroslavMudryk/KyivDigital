using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ActiveSession
    {
        [JsonPropertyName("car")]
        public CarModel Car { get; set; }
        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("lasts_for")]
        public long LastsFor { get; set; }
        [JsonPropertyName("place")]
        public Place Place { get; set; }
        [JsonPropertyName("sum")]
        public int Sum { get; set; }
    }
}