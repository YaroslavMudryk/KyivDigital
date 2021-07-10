using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Card
    {
        [JsonPropertyName("discount")]
        public string Discount { get; set; }
        [JsonPropertyName("expired")]
        public bool Expired { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("isSelected")]
        public bool IsSelected { get; set; }
        [JsonPropertyName("main")]
        public bool Main { get; set; }
        [JsonPropertyName("mask")]
        public string Mask { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("subtitle")]
        public bool Subtitle { get; set; }
        [JsonPropertyName("type")]
        public CardType Type { get; set; }
    }
}