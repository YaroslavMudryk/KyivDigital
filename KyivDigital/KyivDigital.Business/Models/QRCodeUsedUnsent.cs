using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class QRCodeUsedUnsent
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("used_at")]
        public long UsedAt { get; set; }
    }
}
