using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Address
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("main")]
        public bool IsMain { get; set; }
        [JsonPropertyName("postcode")]
        public object Postcode { get; set; }
        [JsonPropertyName("country")]
        public object Country { get; set; }
        [JsonPropertyName("area")]
        public object Area { get; set; }
        [JsonPropertyName("district")]
        public string District { get; set; }
        [JsonPropertyName("city")]
        public object City { get; set; }
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("house")]
        public string House { get; set; }
        [JsonPropertyName("frame")]
        public object Frame { get; set; }
        [JsonPropertyName("flat")]
        public string Flat { get; set; }
        [JsonPropertyName("street_id")]
        public string StreetId { get; set; }
        [JsonPropertyName("ao_id")]
        public string AoId { get; set; }
        [JsonPropertyName("premise_id")]
        public string PremiseId { get; set; }
    }
}
