using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class AoAddressResponse : FaqItemResponse
    {
        [JsonPropertyName("aos")]
        public List<AddressPart> Houses { get; set; }
    }
}