using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class HeadLineModel : BaseResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("fcm_token")]
        public string HeadlineToken { get; set; }
        [JsonPropertyName("min_version")]
        public string MinVersion { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("profile_version")]
        public int ProfileVersion { get; set; }
        [JsonPropertyName("qrs_version")]
        public int QrsVersion { get; set; }
        [JsonPropertyName("speed_dial")]
        public List<SpeedDial> SpeedDial { get; set; }
        [JsonPropertyName("tcs_version")]
        public int TcsVersion { get; set; }
        [JsonPropertyName("weather")]
        public Weather Weather { get; set; }
    }
}
