using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class DownloadButton
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
