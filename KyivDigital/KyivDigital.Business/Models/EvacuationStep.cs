using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class EvacuationStep
    {
        [JsonPropertyName("completed")]
        public bool IsCompleted { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("download_button")]
        public DownloadButton DownloadButton { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("qr_button")]
        public QrButton QrButton { get; set; }
        [JsonPropertyName("re_upload_button")]
        public ReUploadButton ReUploadButton { get; set; }
        [JsonPropertyName("surcharge_button")]
        public bool IsSurchargeButton { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("warn_text")]
        public string WarnText { get; set; }
        [JsonPropertyName("warn_text_red")]
        public bool IsWarnTextRed { get; set; }
    }
}
