using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Category
    {
        [JsonPropertyName("active")]
        public bool active { get; set; }
        [JsonPropertyName("category_Order")]
        public int categoryOrder { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("services")]
        public List<ServiceModel> Services { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}