using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Body
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("elements")]
        public List<string> Elements { get; set; }
    }
}