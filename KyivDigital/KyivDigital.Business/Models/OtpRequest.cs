using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class OtpRequest
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}