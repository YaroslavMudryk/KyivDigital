using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class TransportRouteSaveStateRequest
    {
        [JsonPropertyName("state")]
        public bool State { get; set; }
    }
}
