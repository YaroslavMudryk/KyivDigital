using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class Data
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("average_bill")]
        public string AverageBill { get; set; }
        [JsonPropertyName("finish_date")]
        public int FinishDate { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("start_date")]
        public int StartDate { get; set; }
        [JsonPropertyName("ticket_mode")]
        public string TicketMode { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
