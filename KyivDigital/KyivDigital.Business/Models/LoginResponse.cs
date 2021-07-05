using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class LoginResponse : BaseResponse
    {
        [JsonPropertyName("success")]
        public bool IsSuccess { get; set; } 
        [JsonPropertyName("retry_after")]
        public int RetryAfter { get; set; }
    }
}