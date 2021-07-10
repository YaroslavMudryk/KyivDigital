using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class ServiceResponse
    {
        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; }
    }
}