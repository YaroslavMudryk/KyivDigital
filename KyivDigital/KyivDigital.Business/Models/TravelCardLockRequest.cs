using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TravelCardLockRequest
    {
        [JsonPropertyName("lock")]
        public bool Lock { get; set; }
    }
}