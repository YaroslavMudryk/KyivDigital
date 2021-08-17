using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ProjectFilter
    {
        [JsonPropertyName("categories")]
        public List<PublicBudgetProjectCategory> Categories { get; set; }
        [JsonPropertyName("districts")]
        public List<ProjectDistrict> Districts { get; set; }
    }
}
