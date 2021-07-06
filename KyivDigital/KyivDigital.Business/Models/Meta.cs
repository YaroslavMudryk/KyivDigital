using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Meta
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
