using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class MonthlyProduct
    {
        [JsonPropertyName("isSelected")]
        public bool IsSelected { get; set; }
        [JsonPropertyName("sum")]
        public int Sum { get; set; }
        [JsonPropertyName("units")]
        public int Units { get; set; }
    }
}