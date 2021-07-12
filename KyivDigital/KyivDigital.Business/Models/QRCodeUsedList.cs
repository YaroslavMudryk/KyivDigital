using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class QRCodeUsedList
    {
        [JsonPropertyName("qrs")]
        public List<QRCodeUsedUnsent> Qrs { get; set; }
    }
}
