using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class CarVerificationRequest
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }
        [JsonPropertyName("own")]
        public bool IsOwn { get; set; }
    }
}