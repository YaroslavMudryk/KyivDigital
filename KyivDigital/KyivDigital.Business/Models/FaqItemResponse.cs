using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FaqItemResponse
    {
        [JsonPropertyName("faq_category")]
        public FaqItem FaqCategory { get; set; }
        [JsonPropertyName("faq_question")]
        public FaqItem FaqQuestion { get; set; }
    }
}