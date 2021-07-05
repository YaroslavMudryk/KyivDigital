using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Phone
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("phone")]
        public string PhoneNumer { get; set; }
    }
}
