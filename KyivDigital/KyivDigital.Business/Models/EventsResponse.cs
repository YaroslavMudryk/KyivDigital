using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class EventsResponse
    {
        [JsonPropertyName("events")]
        public Events Events { get; set; }
        [JsonPropertyName("screen_title")]
        public string ScreenTitle { get; set; }
    }
}