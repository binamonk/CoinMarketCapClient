using Newtonsoft.Json;

namespace CoinMarketCap.Entities
{
    /// <summary>
    /// Cryptocurrency listing item.
    /// </summary>
    public class ListingItem
    {
        /// <summary>
        /// Crypto Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Crypto Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Crypto Symbol.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// CoinMarketCap.com url name.
        /// Example: http://coinmarketcap.com/currencies/{website_slug}
        /// </summary>
        [JsonProperty("website_slug")]
        public string WebsiteSlug { get; set; }
    }
}
