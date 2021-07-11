using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ZonePricesResponse
    {
        [JsonPropertyName("prices")]
        public Prices Prices { get; set; }
    }
}
