using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class WalletReplenishResponse
    {
        [JsonPropertyName("balance_wallet")]
        public int BalanceWallet { get; set; }
        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }
    }
}