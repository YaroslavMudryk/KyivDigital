using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Phone
    {
        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
