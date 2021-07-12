using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class QRCodeShareModel
    {
        [JsonPropertyName("shared")]
        public bool IsShared { get; set; }
    }
}