using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FineSendEmailRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}