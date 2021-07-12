using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Profile : BaseResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
        [JsonPropertyName("bankid_connected")]
        public bool BankidConnected { get; set; }
        [JsonPropertyName("profile")]
        public ProfileAction[] Actions { get; set; }
        [JsonPropertyName("share_content")]
        public string ShareContent { get; set; }
        [JsonPropertyName("version")]
        public int? Version { get; set; }
        [JsonPropertyName("emails")]
        public List<Email> Emails { get; set; }
        [JsonPropertyName("phones")]
        public List<Phone> Phones { get; set; }
    }
}