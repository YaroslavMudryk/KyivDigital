using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FaqItem
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}