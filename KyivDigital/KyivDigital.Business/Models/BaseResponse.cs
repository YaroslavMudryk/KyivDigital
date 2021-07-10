using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class BaseResponse
    {
        [JsonPropertyName("message_advanced")]
        public AdvancedErrorMessage MessageAdvanced { get; set; }
        [JsonPropertyName("message")]
        public string ErrorMessage { get; set; }
        public bool IsSuccess
        {
            get => isSuccess || ErrorMessage == null;
            set => isSuccess = value;
        }

        private bool isSuccess;
    }
}