using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class CarVerificationDataResponse
    {
        [JsonPropertyName("bankid_connected")]
        public bool BankIdConnected { get; set; }
        [JsonPropertyName("car_number")]
        public string CarNumber { get; set; }
        [JsonPropertyName("owner_pib")]
        public string OwnerPib { get; set; }
    }
}