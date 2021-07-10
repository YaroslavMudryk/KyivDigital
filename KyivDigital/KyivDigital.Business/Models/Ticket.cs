using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Ticket
    {
        [JsonPropertyName("unit_price")]
        public int UnitPrice { get; set; }
        [JsonPropertyName("units")]
        public int Units { get; set; }
    }
}