using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class AddOrEditAddressRequest
    {
        [JsonPropertyName("ao")]
        private string Ao { get; set; }
        [JsonPropertyName("premise")]
        private string Premise { get; set; }
    }
}
