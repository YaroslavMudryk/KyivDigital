using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class VoteRequest
    {
        [JsonPropertyName("vote")]
        public bool Vote { get; set; }
    }
}
