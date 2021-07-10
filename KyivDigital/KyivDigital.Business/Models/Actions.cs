using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Actions
    {
        [JsonPropertyName("block")]
        public bool Block { get; set; }
        [JsonPropertyName("buy_monthly")]
        public bool BuyMonthly { get; set; }
        [JsonPropertyName("rename")]
        public bool Rename { get; set; }
        [JsonPropertyName("replace")]
        public bool Replace { get; set; }
        [JsonPropertyName("replenishment")]
        public bool Replenishment { get; set; }
    }
}
