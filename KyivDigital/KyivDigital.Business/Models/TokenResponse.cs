using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TokenResponse : BaseResponse
    {
        [JsonPropertyName("token")]
        public Token Token { get; set; }
        [JsonPropertyName("min_version")]
        public string MinVersion { get; set; }
        [JsonPropertyName("profile")]
        public Profile Profile { get; set; }
    }
}