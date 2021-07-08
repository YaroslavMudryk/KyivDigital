using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class AdressesListModel
    {
        [JsonPropertyName("addresses")]
        public Address[] Addresses { get; set; }
    }
}