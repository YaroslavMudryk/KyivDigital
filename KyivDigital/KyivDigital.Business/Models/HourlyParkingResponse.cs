using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class HourlyParkingResponse
    {
        [JsonPropertyName("active_session")]
        public ActiveSession ActiveSession { get; set; }
        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }
        [JsonPropertyName("cars")]
        public List<CarModel> Cars { get; set; }
        [JsonPropertyName("closest_place")]
        public Place ClosestPlace { get; set; }
        [JsonPropertyName("debt")]
        public int Debt { get; set; }
        [JsonPropertyName("faq_category_id")]
        public int FaqCategoryId { get; set; }
        [JsonPropertyName("free_message")]
        public string FreeMessage { get; set; }
        [JsonPropertyName("payment_error")]
        public bool PaymentError { get; set; }
        [JsonPropertyName("payment_message")]
        public string PaymentMessage { get; set; }
        [JsonPropertyName("places_list_hash")]
        public string PlacesListHash { get; set; }
    }
}