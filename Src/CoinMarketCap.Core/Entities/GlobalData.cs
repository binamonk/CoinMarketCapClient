using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CoinMarketCap.Entities
{
    /// <summary>
    /// Global cryptocurrencies data.
    /// </summary>
    public class GlobalData
    {
        /// <summary>
        /// Number of active cryptocurrencies.
        /// </summary>
        [JsonProperty("active_cryptocurrencies")]
        public int ActiveCryptocurrencies { get; set; }
        /// <summary>
        /// Number of active markets.
        /// </summary>
        [JsonProperty("active_markets")]
        public int ActiveMarkets { get; set; }
        /// <summary>
        /// Bitcoin percentage of market capitalization.
        /// </summary>
        [JsonProperty("bitcoin_percentage_of_market_cap")]
        public decimal BitcoinPercentageOfMarketCap { get; set; }
        /// <summary>
        /// Estimated value.
        /// </summary>
        [JsonProperty("quotes")]
        public Dictionary<string,GlobalQuote> Quotes { get; set; }
        /// <summary>
        /// Last update in unix format.
        /// </summary>
        [JsonProperty("last_updated")]
        public long LastUpdated { get; set; }

        /// <summary>
        /// Last update in local datetime.
        /// </summary>
        public DateTime LastUpdatedDate
        {
            get => new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
                        .AddSeconds(LastUpdated)
                        .ToLocalTime();
        }
    }
}
