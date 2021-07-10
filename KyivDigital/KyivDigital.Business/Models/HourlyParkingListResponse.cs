using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class HourlyParkingListResponse
    {
        [JsonPropertyName("list")]
        public List<HourlyParking> List { get; set; }
        [JsonPropertyName("list_hash")]
        public string ListHash { get; set; }
    }
}