using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace CoinMarketCap.Entities
{
    /// <summary>
    /// Ticker information.
    /// </summary>
    public class Ticker
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
        /// <summary>
        /// Crypto Rank.
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }
        /// <summary>
        /// Circulating Supply.
        /// </summary>
        [JsonProperty("circulating_supply")]
        public decimal CirculatingSupply { get; set; }
        /// <summary>
        /// Total Supply.
        /// </summary>
        [JsonProperty("total_supply")]
        public decimal TotalSupply { get; set; }
        /// <summary>
        /// Max Supply.
        /// </summary>
        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; }
        /// <summary>
        /// Quotes dictionary.
        /// Key: Fiat currency in uppercase.
        /// Value: Quote.
        /// </summary>
        [JsonProperty("quotes")]
        public Dictionary<string,Quote> Quotes { get; set; }
        /// <summary>
        /// Last updated unix timestamp.
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
