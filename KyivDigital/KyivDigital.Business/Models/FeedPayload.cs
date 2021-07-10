using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FeedPayload
    {
        [JsonPropertyName("qr")]
        public QRCodeModel Qr { get; set; }
    }
}