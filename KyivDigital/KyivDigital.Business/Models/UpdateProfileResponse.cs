using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class UpdateProfileResponse
    {
        [JsonPropertyName("profile")]
        public Profile Profile { get; set; }
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}