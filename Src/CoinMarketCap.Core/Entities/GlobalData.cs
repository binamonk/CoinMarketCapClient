using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoinMarketCap.Entities
{
    public class GlobalData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; } 
        [JsonProperty("symbol")]
        public string Symbol { get; set; } 
        [JsonProperty("website_slug")]
        public string WebsiteSlug { get; set; } 
        [JsonProperty("Rank")]
        public int Rank { get; set; } 
        [JsonProperty("circulating_supply")]
        public decimal CirculatingSupply { get; set; } 
        [JsonProperty("total_supply")]
        public decimal TotalSupply { get; set; } 
        [JsonProperty("max_supply")]
        public decimal MaxSupply { get; set; } 
        [JsonProperty("quotes")]
        public Dictionary<string,GlobalData> Quotes { get; set; } 
        [JsonProperty("last_updated")]
        public long LastUpdated { get; set; } 
    }
}
