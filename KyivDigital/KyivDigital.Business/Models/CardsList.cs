using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class CardsList
    {
        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }
    }
}