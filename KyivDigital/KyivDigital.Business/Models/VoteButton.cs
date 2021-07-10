using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class VoteButton
    {
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("rate")]
        public int Rate { get; set; }
        [JsonPropertyName("selected")]
        public bool IsSelected { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}