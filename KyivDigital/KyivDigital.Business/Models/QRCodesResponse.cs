using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class QRCodesResponse
    {
        [JsonPropertyName("codes")]
        public List<QRCodeModel> Codes { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}
