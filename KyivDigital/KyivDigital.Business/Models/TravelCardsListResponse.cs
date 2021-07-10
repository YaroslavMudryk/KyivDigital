using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TravelCardsListResponse
    {
        [JsonPropertyName("cards")]
        public List<TravelCardModel> Cards { get; set; }
        [JsonPropertyName("faq_category_id")]
        public int FaqCategoryId { get; set; }
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}