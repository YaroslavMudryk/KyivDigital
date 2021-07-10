using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Place
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("center_point")]
        public CenterPoint CenterPoint { get; set; }
        [JsonPropertyName("isClosest")]
        public bool IsClosest { get; set; }
        [JsonPropertyName("isSelected")]
        public bool IsSelected { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("parking_lots")]
        public int ParkingLots { get; set; }
        [JsonPropertyName("payload")]
        public Payload Payload { get; set; }
        [JsonPropertyName("polygons")]
        public List<List<CenterPoint>> Polygons { get; set; }
        [JsonPropertyName("priceInfo")]
        public string PriceInfo { get; set; }
        [JsonPropertyName("price_sub_text")]
        public string PriceSubText { get; set; }
        [JsonPropertyName("price_text")]
        public string PriceText { get; set; }
        [JsonPropertyName("pricing")]
        public List<Pricing> Pricing { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}