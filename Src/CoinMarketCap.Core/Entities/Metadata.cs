using Newtonsoft.Json;

namespace CoinMarketCap.Entities
{
    /// <summary>
    /// Response metadata.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Timestamp in unix format.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        /// <summary>
        /// Amount of cryptocurrencies.
        /// </summary>
        [JsonProperty("num_cryptocurrencies")]
        public int NumCryptocurrencies { get; set; }
        /// <summary>
        /// Error message.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
