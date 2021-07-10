using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class NewUserModel
    {
        [JsonPropertyName("actions")]
        public List<ProfileAction> Actions { get; set; }
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
        [JsonPropertyName("bankid_connected")]
        public bool BankidConnected { get; set; }
        [JsonPropertyName("emails")]
        public List<Email> Emails { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }
        [JsonPropertyName("phones")]
        public List<Phone> Phones { get; set; }
        [JsonPropertyName("share_content")]
        public string ShareContent { get; set; }
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}
