using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class CarTicket
    {
        [JsonPropertyName("period")]
        public string Period { get; set; }
        [JsonPropertyName("zone")]
        public int Zone { get; set; }
    }
}
