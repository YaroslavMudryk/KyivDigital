using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class PhoneModel
    {
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    }
}