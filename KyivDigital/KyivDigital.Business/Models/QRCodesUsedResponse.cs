using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class QRCodesUsedResponse
    {
        [JsonPropertyName("qrs")]
        public List<QRCodeModel> Qrs { get; set; }
    }
}
