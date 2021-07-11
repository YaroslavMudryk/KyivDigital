using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class AddressPart
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("type")]
        public AddressType AddressType { get; set; }
    }
}