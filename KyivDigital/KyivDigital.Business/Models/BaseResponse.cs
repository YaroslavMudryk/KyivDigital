using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class BaseResponse
    {
        [JsonPropertyName("message")]
        public string ErrorMessage { get; set; }
        public bool IsSuccess => ErrorMessage == null;
    }
}