using Newtonsoft.Json;

namespace CoinMarketCap.Entities
{
    /// <summary>
    /// Estimated cost.
    /// </summary>
    public class Quote
    {
        /// <summary>
        /// The price.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Volume in the last 24 hours.
        /// </summary>
        [JsonProperty("volume_24h")]
        public decimal Volume24h { get; set; }
        /// <summary>
        /// Market capitalization.
        /// </summary>
        [JsonProperty("market_cap")]
        public decimal MarketCap { get; set; }
        /// <summary>
        /// Percent change in the last hour.
        /// </summary>
        [JsonProperty("percent_change_1h")]
        public decimal PercentChange1h { get; set; }
        /// <summary>
        /// Percent change in the last 24 hours.
        /// </summary>
        [JsonProperty("percent_change_24h")]
        public decimal PercentChange24h { get; set; }
        /// <summary>
        /// Percent change in the last 7 days.
        /// </summary>
        [JsonProperty("percent_change_7d")]
        public decimal PercentChange7d { get; set; }
    }
}
