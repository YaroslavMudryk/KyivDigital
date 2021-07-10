using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Events
    {
        [JsonPropertyName("data")]
        public List<Data> EventsData { get; set; }
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}
