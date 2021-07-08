using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Topic
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("subscribed")]
        public bool Subscribed { get; set; }
    }
}