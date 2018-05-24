using Newtonsoft.Json;

namespace CoinMarketCap.Entities
{
    /// <summary>
    /// Global estimated value.
    /// </summary>
    public class GlobalQuote
    {
        /// <summary>
        /// Total market capitalization.
        /// </summary>
        [JsonProperty("total_market_cap")]
        public decimal TotalMarketCap { get; set; }
        /// <summary>
        /// Total volume in the last 24h.
        /// </summary>
        [JsonProperty("total_volume_24h")]
        public decimal TotalVolume24h { get; set; }
    }
}
