using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FinePaymentRequest
    {
        [JsonPropertyName("car_number")]
        public string CarNumber { get; set; }
        [JsonPropertyName("card_id")]
        public long CardId { get; set; }
        [JsonPropertyName("google_token")]
        public string GoogleToken { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("order_token")]
        public string OrderToken { get; set; }
        [JsonPropertyName("pib")]
        public string Pib { get; set; }
        [JsonPropertyName("region_id")]
        public int RegionId { get; set; }
        [JsonPropertyName("series")]
        public string Series { get; set; }
        [JsonPropertyName("sum")]
        public int Sum { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("uniq_id")]
        public string UniqId { get; set; }
    }
}