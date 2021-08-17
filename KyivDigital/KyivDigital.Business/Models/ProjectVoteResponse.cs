using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ProjectVoteResponse
    {
        [JsonPropertyName("error")]
        public ProjectError Error { get; set; }
        [JsonPropertyName("project")]
        public ProjectDetailsResponse Project { get; set; }
        [JsonPropertyName("success")]
        public bool IsSuccess { get; set; }
    }
}