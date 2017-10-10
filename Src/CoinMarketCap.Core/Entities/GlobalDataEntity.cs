using Newtonsoft.Json;

namespace CoinMarketCap.Entities
{
    /// <summary>
    /// Global market cap information entity.
    /// </summary>
    public class GlobalDataEntity
    {
        /// <summary>
        /// Market capitalization in USD.
        /// </summary>
        [JsonProperty("total_market_cap_usd")]
        public double MarketCapUsd { get; set; }
        /// <summary>
        /// Market volume in the last 24 hours.
        /// </summary>
        [JsonProperty("total_24h_volume_usd")]
        public double Volume24hUsd { get; set; }
        /// <summary>
        /// Bitcoin percentage of total market capitalization.
        /// </summary>
        [JsonProperty("bitcoin_percentage_of_market_cap")]
        public double BTCPercentageOfMarketCap { get; set; }
        /// <summary>
        /// Number of active crypto currencies.
        /// </summary>
        [JsonProperty("active_currencies")]
        public int ActiveCurrencies { get; set; }
        /// <summary>
        /// Number of active assets.
        /// </summary>
        [JsonProperty("active_assets")]
        public int ActiveAssets { get; set; }
        /// <summary>
        /// Number of active markets.
        /// </summary>
        [JsonProperty("active_markets")]
        public int ActiveMarkets { get; set; }
    }
}
