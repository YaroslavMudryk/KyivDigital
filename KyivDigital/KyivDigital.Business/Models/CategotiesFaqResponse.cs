using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class CategotiesFaqResponse
    {
        [JsonPropertyName("categories")]
        public List<CategoryFaq> Categories { get; set; }
        [JsonPropertyName("link_1551")]
        public string Link1551 { get; set; }
    }
}