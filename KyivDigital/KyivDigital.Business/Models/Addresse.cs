using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Addresse
    {
        [JsonPropertyName("ao_id")]
        public string AoId { get; set; }
        [JsonPropertyName("area")]
        public string Area { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("district")]
        public string District { get; set; }
        [JsonPropertyName("flat")]
        public string Flat { get; set; }
        [JsonPropertyName("frame")]
        public string Frame { get; set; }
        [JsonPropertyName("house")]
        public string House { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        public bool IsAddressesNotEmpty { get; set; }
        [JsonPropertyName("main")]
        public bool IsMain { get; set; }
        [JsonPropertyName("postcode")]
        public string Postcode { get; set; }
        [JsonPropertyName("premise_id")]
        public string PremiseId { get; set; }
        public bool ShowMain { get; set; }
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("street_id")]
        public string StreetId { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}