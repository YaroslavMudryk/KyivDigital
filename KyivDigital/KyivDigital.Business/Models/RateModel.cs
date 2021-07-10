using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class RateModel
    {
        [JsonPropertyName("rate")]
        public int Rate { get; set; }
    }
}