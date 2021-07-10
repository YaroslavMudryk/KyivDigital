using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Email
    {
        [JsonPropertyName("email")]
        public string EmailAddress { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}