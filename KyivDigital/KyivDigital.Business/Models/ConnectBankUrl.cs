using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ConnectBankUrl
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}