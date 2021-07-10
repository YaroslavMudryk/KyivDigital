using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class RateFaqRequest
    {
        [JsonPropertyName("rate")]
        public bool Rate { get; set; }
    }
}
