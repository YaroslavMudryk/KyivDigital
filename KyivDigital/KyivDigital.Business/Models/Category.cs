using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("sub_title")]
        public string SubTitle { get; set; }
        [JsonPropertyName("topics")]
        public Topic[] Topics { get; set; }
    }
}