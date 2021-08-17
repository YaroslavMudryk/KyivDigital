using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ProjectVoting
    {
        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }
        [JsonPropertyName("voted")]
        public bool Voted { get; set; }
    }
}