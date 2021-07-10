using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class NotificationChangeRequest
    {
        [JsonPropertyName("state")]
        public bool State { get; set; }
    }
}