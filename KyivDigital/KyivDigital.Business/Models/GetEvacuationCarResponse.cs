using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class GetEvacuationCarResponse
    {
        [JsonPropertyName("cars")]
        public List<EvacuatedCar> Cars { get; set; }
        [JsonPropertyName("faq_category_id")]
        public int FaqCategoryId { get; set; }
    }
}
