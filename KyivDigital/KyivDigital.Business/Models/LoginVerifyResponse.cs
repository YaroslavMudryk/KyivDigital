using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class LoginVerifyResponse : BaseResponse
    {
        [JsonPropertyName("min_version")]
        public string MinVersion { get; set; }
        [JsonPropertyName("profile")]
        public Profile Profile { get; set; }
        [JsonPropertyName("token")]
        public TokenModel TokenModel { get; set; }
    }
}