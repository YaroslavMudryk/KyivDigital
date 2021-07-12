using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class QRCodeUsedModel
    {
        [JsonPropertyName("used_at")]
        public long UsedAt { get; set; }
    }
}
