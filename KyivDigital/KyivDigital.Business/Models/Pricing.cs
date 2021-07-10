using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Pricing
    {
        [JsonPropertyName("hours")]
        public double Hours { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}