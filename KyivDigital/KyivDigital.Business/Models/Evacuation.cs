using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Evacuation
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("evidence_file")]
        public string EvidenceFile { get; set; }
        [JsonPropertyName("issued_at")]
        public long IssuedAt { get; set; }
        [JsonPropertyName("issued_by")]
        public int IssuedBy { get; set; }
        [JsonPropertyName("issued_by_text")]
        public string IssuedByText { get; set; }
        [JsonPropertyName("payment_allowed")]
        public bool PaymentAllowed { get; set; }
        [JsonPropertyName("photos")]
        public List<string> Photos { get; set; }
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("return_steps")]
        public List<EvacuationStep> Steps { get; set; }
    }
}
