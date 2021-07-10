using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class EventModel
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("average_bill")]
        public string AverageBill { get; set; }
        [JsonPropertyName("body")]
        public string Body { get; set; }
        [JsonPropertyName("finish_date")]
        public long FinishDate { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        [JsonPropertyName("liked")]
        public bool IsLiked { get; set; }
        [JsonPropertyName("lng")]
        public double Lng { get; set; }
        [JsonPropertyName("start_date")]
        public long StartDate { get; set; }
        [JsonPropertyName("ticket_mode")]
        public string TicketMode { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("url_buy_tickets")]
        public string UrlBuyTickets { get; set; }
        [JsonPropertyName("url_social")]
        public string UrlSocial { get; set; }
    }
}