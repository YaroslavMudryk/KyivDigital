using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class CheckEvacuationCarResponse
    {
        [JsonPropertyName("car")]
        public CarModel Car { get; set; }
        [JsonPropertyName("evacuation")]
        public Evacuation Evacuation { get; set; }
        [JsonPropertyName("forget_documents_text")]
        public string ForgetDocumentsText { get; set; }
    }
}