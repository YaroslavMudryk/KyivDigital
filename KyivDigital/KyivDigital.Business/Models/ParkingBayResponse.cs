using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class ParkingBayResponse
    {
        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }
        [JsonPropertyName("cars")]
        public List<CarModel> Cars { get; set; }
        [JsonPropertyName("copy_autofill")]
        public CopyAutofill CopyAutofill { get; set; }
        [JsonPropertyName("months")]
        public List<int> Months { get; set; }
        [JsonPropertyName("prices")]
        public Prices Prices { get; set; }
    }
}