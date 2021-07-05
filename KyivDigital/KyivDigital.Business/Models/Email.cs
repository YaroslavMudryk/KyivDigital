using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Email
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("email")]
        public string EmailAddress { get; set; }
    }
}
