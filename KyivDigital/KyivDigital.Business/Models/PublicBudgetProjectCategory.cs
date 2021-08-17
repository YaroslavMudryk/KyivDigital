using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class PublicBudgetProjectCategory
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("isSelected")]
        public bool IsSelected { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}
