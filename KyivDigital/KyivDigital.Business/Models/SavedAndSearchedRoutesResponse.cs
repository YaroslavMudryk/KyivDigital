using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class SavedAndSearchedRoutesResponse
    {
        [JsonPropertyName("faq_category_id")]
        public long FaqCategoryId { get; set; }
        [JsonPropertyName("saved_routes")]
        public List<TransportRoute> SavedRoutes { get; set; }
        [JsonPropertyName("searched_items")]
        public List<object> SearchedItems { get; set; }
        [JsonPropertyName("stops_list_hash")]
        public string StopsListHash { get; set; }
    }
}
