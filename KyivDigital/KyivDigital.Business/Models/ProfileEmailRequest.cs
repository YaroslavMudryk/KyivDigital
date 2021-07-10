using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ProfileEmailRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}