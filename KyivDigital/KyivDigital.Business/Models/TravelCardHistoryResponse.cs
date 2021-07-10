using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TravelCardHistoryResponse
    {
        [JsonPropertyName("history")]
        public List<TravelCardHistoryModel> History { get; set; }
    }
}