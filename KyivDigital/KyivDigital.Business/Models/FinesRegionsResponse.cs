using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FinesRegionsResponse
    {
        [JsonPropertyName("regions")]
        public List<FinesRegion> Regions { get; set; }
    }
}