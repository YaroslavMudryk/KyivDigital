using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Token
    {
        [JsonPropertyName("profile")]
        public string access_token { get; set; }
        [JsonPropertyName("profile")]
        public string token_type { get; set; }
        [JsonPropertyName("profile")]
        public int expires_in { get; set; }
    }
}
