using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class MonthlyProductsResponse
    {
        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }
        [JsonPropertyName("products")]
        public List<MonthlyProduct> Products { get; set; }
        [JsonPropertyName("tariff")]
        public int Tariff { get; set; }
    }
}