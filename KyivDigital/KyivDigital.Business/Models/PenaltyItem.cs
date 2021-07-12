using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class PenaltyItem
    {
        [JsonPropertyName("discount_sum")]
        public int DiscountSum { get; set; }
        [JsonPropertyName("sub_title")]
        public string SubTitle { get; set; }
        [JsonPropertyName("sum")]
        public int Sum { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}