using Newtonsoft.Json;

namespace CoinMarketCap.Entities
{
    public class Metadata
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        [JsonProperty("num_cryptocurrencies")]
        public int NumCryptocurrencies { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
