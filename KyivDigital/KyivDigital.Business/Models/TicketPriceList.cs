using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TicketPriceList
    {
        [JsonPropertyName("tickets")]
        public List<Ticket> Tickets { get; set; }
    }
}