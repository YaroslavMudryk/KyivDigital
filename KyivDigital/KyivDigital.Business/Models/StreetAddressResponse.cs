using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class StreetAddressResponse : FaqItemResponse
    {
        [JsonPropertyName("streets")]
        public List<AddressPart> Streets { get; set; }
    }
}