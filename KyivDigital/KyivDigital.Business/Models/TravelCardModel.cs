using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class TravelCardModel
    {
        [JsonPropertyName("actions")]
        public Actions actions { get; set; }
        [JsonPropertyName("balance")]
        public int Balance { get; set; }
        [JsonPropertyName("balance_wallet")]
        public int BalanceWallet { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("locked_at")]
        public int LockedAt { get; set; }
        [JsonPropertyName("monthly_ticket")]
        public MonthlyTicket MonthlyTicket { get; set; }
        [JsonPropertyName("monthly_ticket_purchase")]
        public MonthlyTicketPurchase MonthlyTicketPurchase { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public int Type { get; set; }
    }
}