using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Tickets
    {
        [JsonPropertyName("data")]
        public List<Data> DataTickets { get; set; }
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}
