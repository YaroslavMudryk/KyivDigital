using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class ReUploadButton
    {
        [JsonPropertyName("forget_documents_text")]
        public string ForgetDocumentsText { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
