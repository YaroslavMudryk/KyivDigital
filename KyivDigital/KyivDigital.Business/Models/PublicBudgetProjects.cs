using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class PublicBudgetProjects
    {
        [JsonPropertyName("data")]
        public List<PublicBudgetProject> Projects { get; set; }
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}
