using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class QRCodeModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("expire_at")]
        public long ExpireAt { get; set; }
        [JsonPropertyName("shared")]
        public bool IsShared { get; set; }
        [JsonPropertyName("used")]
        public bool IsUsed { get; set; }
    }
}
