using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FinesPaymentFeedResponse
    {
        [JsonPropertyName("payments")]
        public FinesFeedData Payments { get; set; }
    }
}