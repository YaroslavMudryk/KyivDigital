using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class MonthlyTicket
    {
        [JsonPropertyName("balance")]
        public int Balance { get; set; }
        [JsonPropertyName("valid_until")]
        public long ValidUntil { get; set; }
    }
}
