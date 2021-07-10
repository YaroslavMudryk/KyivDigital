using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class FaqTopic
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("question")]
        public string Question { get; set; }
    }
}
