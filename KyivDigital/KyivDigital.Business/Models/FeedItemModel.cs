using KyivDigital.Business.Helpers;
using System;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class FeedItemModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("clickable")]
        public bool Clickable { get; set; }
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }
        public string CreatedTimeTitle => DateTimeHelper.GetTitleTime(CreatedAt);
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("payload")]
        public FeedPayload Payload { get; set; }
        [JsonPropertyName("read")]
        public bool IsRead { get; set; }
        [JsonPropertyName("sub_icon")]
        public string SubIcon { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("value_img")]
        public string ValueImg { get; set; }
        [JsonPropertyName("value_sum")]
        public int? ValueSum { get; set; }
        [JsonPropertyName("value_text")]
        public string ValueText { get; set; }
    }
}