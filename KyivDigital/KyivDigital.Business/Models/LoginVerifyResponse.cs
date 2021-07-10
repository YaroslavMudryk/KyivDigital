using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class LoginVerifyResponse
    {
        [JsonPropertyName("min_version")]
        public string MinVersion { get; set; }
        [JsonPropertyName("profile")]
        public NewUserModel Profile { get; set; }
        [JsonPropertyName("token")]
        public TokenModel TokenModel { get; set; }
    }
}