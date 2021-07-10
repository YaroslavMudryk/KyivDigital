using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class MainCardRequest
    {
        [JsonPropertyName("main")]
        public bool Main { get; set; }
    }
}