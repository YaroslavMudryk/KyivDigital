using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FinesResponse
    {
        [JsonPropertyName("cars")]
        public List<CarModel> Cars { get; set; }
        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; }
        [JsonPropertyName("faq_category_id")]
        public int FaqCategoryId { get; set; }
        [JsonPropertyName("pending_penalties")]
        public List<PendingPenalties> PendingPenalties { get; set; }
    }
}