using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class CarsResponse
    {
        [JsonPropertyName("cars")]
        public List<CarModel> Cars { get; set; }
    }
}