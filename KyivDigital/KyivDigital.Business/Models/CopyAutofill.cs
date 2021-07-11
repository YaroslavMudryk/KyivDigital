using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class CopyAutofill
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("np_office_num")]
        public string NpOfficeNum { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    }
}
