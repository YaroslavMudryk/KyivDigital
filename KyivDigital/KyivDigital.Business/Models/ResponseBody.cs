using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class ResponseBody
    {
        [JsonPropertyName("success")]
        public bool IsSuccess { get; set; }
        [JsonPropertyName("retry_after")]
        public int RetryAfter { get; set; }
    }
}