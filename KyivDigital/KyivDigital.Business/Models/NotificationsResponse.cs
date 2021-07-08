using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class NotificationsResponse
    {
        [JsonPropertyName("notifications_enabled")]
        public bool NotificationsEnabled { get; set; }
        [JsonPropertyName("categories")]
        public Category[] Categories { get; set; }
    }
}