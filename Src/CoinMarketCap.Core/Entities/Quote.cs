using Newtonsoft.Json;

namespace CoinMarketCap.Entities
{
    public class Quote
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("volume_24h")]
        public decimal Volume24h { get; set; }
        [JsonProperty("market_cap")]
        public decimal MarketCap { get; set; }
        [JsonProperty("percent_change_1h")]
        public decimal PercentChange1h { get; set; }
        [JsonProperty("percent_change_24h")]
        public decimal PercentChange24h { get; set; }
        [JsonProperty("percent_change_7d")]
        public decimal PercentChange7d { get; set; }
    }
}
