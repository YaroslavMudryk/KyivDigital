using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FineCheckCarResponse
    {
        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }
        [JsonPropertyName("fee_percent")]
        public double FeePercent { get; set; }
        [JsonPropertyName("penalties")]
        public List<FinePenalty> Penalties { get; set; }
        [JsonPropertyName("penalty")]
        public FinePenalty Penalty { get; set; }
        [JsonPropertyName("regions")]
        public List<FinesRegion> Regions { get; set; }
    }
}