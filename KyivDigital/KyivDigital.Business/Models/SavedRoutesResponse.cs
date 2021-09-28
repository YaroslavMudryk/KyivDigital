using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class SavedRoutesResponse
    {
        [JsonPropertyName("saved_routes")]
        public List<TransportRoute> SavedRoutes { get; set; }
    }
}