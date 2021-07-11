using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class PremiseAddressResponse : FaqItemResponse
    {
        [JsonPropertyName("premises")]
        public List<AddressPart> Flats { get; set; }
    }
}