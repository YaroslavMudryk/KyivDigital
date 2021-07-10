using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyivDigital.Business.Models
{
    public class CarModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("isSelected")]
        public bool IsSelected { get; set; }
        [JsonPropertyName("isShowMain")]
        public bool IsShowMain { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("main")]
        public bool IsMain { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("session_lasts_for")]
        public long sessionLastsFor { get; set; }
        [JsonPropertyName("ticket_period")]
        public string ticketPeriod { get; set; }
        [JsonPropertyName("tickets")]
        public List<CarTicket> Tickets { get; set; }
        [JsonPropertyName("usual_format")]
        public bool UsualFormat { get; set; }
        [JsonPropertyName("verified")]
        public bool IsVerified { get; set; }
    }
}
