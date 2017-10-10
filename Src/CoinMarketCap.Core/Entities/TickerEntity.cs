using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CoinMarketCap.Entities
{
    /// <summary>
    /// Ticker information.
    /// </summary>
    public class TickerEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Rank { get; set; }

        [JsonProperty("price_btc")]
        public double PriceBtc { get; set; }

        [JsonProperty("available_supply")]
        public double? AvailableSupply { get; set; }
        [JsonProperty("total_supply")]
        public double? TotalSupply { get; set; }

        [JsonProperty("percent_change_1h")]
        public double? PercentChange1h { get; set; }
        [JsonProperty("percent_change_24h")]
        public double? PercentChange24h { get; set; }
        [JsonProperty("percent_change_7d")]
        public double? PercentChange7d { get; set; }

        double _lastUpdatedUnixTime;
        [JsonProperty("last_updated")]
        public double LastUpdatedUnixTime {
            get {
                return _lastUpdatedUnixTime;
            }
            set {
                _lastUpdatedUnixTime = value;
                _lastUpdated = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
                    .AddSeconds(value)
                    .ToLocalTime();
            }
        }

        DateTime _lastUpdated;
        public DateTime LastUpdated { get { return _lastUpdated; } }

        public Dictionary<string, double?> PriceOther { get; set; } = new Dictionary<string, double?>();
        public Dictionary<string, double?> Volume24hOther { get; set; } = new Dictionary<string, double?>();
        public Dictionary<string, double?> MarketCapOther { get; set; } = new Dictionary<string, double?>();

        [JsonProperty("price_usd")]
        public double PriceUsd { get { return PriceOther["usd"].Value; } set { PriceOther.Add("usd", value); } }
        [JsonProperty("24h_volume_usd")]
        public double? Volume24hUsd { get { return Volume24hOther["usd"].Value; } set { Volume24hOther.Add("usd", value); } }
        [JsonProperty("market_cap_usd")]
        public double? MarketCapUsd { get { return MarketCapOther["usd"].Value; } set { MarketCapOther.Add("usd", value); } }

        [JsonProperty("price_eur")]
        double? PriceEur { get { return PriceOther["eur"]; } set { PriceOther.Add("eur", value); } }
        [JsonProperty("24h_volume_eur")]
        double? Volume24hEur { get { return Volume24hOther["eur"]; } set { Volume24hOther.Add("eur", value); } }
        [JsonProperty("market_cap_eur")]
        double? MarketCapEur { get { return MarketCapOther["eur"]; } set { MarketCapOther.Add("eur", value); } }

        [JsonProperty("price_aud")]
        double? PriceAud { get { return PriceOther["aud"]; } set { PriceOther.Add("aud", value); } }
        [JsonProperty("24h_volume_aud")]
        double? Volume24hAud { get { return Volume24hOther["aud"]; } set { Volume24hOther.Add("aud", value); } }
        [JsonProperty("market_cap_aud")]
        double? MarketCapAud { get { return MarketCapOther["aud"]; } set { MarketCapOther.Add("aud", value); } }

        [JsonProperty("price_brl")]
        double? PriceBrl { get { return PriceOther["brl"]; } set { PriceOther.Add("brl", value); } }
        [JsonProperty("24h_volume_brl")]
        double? Volume24hBrl { get { return Volume24hOther["brl"]; } set { Volume24hOther.Add("brl", value); } }
        [JsonProperty("market_cap_brl")]
        double? MarketCapBrl { get { return MarketCapOther["brl"]; } set { MarketCapOther.Add("brl", value); } }

        [JsonProperty("price_cad")]
        double? PriceCad { get { return PriceOther["cad"]; } set { PriceOther.Add("cad", value); } }
        [JsonProperty("24h_volume_cad")]
        double? Volume24hCad { get { return Volume24hOther["cad"]; } set { Volume24hOther.Add("cad", value); } }
        [JsonProperty("market_cap_cad")]
        double? MarketCapCad { get { return MarketCapOther["cad"]; } set { MarketCapOther.Add("cad", value); } }

        [JsonProperty("price_chf")]
        double? PriceChf { get { return PriceOther["chf"]; } set { PriceOther.Add("chf", value); } }
        [JsonProperty("24h_volume_chf")]
        double? Volume24hChf { get { return Volume24hOther["chf"]; } set { Volume24hOther.Add("chf", value); } }
        [JsonProperty("market_cap_chf")]
        double? MarketCapChf { get { return MarketCapOther["chf"]; } set { MarketCapOther.Add("chf", value); } }

        [JsonProperty("price_cny")]
        double? PriceCny { get { return PriceOther["cny"]; } set { PriceOther.Add("cny", value); } }
        [JsonProperty("24h_volume_cny")]
        double? Volume24hCny { get { return Volume24hOther["cny"]; } set { Volume24hOther.Add("cny", value); } }
        [JsonProperty("market_cap_cny")]
        double? MarketCapCny { get { return MarketCapOther["cny"]; } set { MarketCapOther.Add("cny", value); } }

        [JsonProperty("price_gbp")]
        double? PriceGbp { get { return PriceOther["gbp"]; } set { PriceOther.Add("gbp", value); } }
        [JsonProperty("24h_volume_gbp")]
        double? Volume24hGbp { get { return Volume24hOther["gbp"]; } set { Volume24hOther.Add("gbp", value); } }
        [JsonProperty("market_cap_gbp")]
        double? MarketCapGbp { get { return MarketCapOther["gbp"]; } set { MarketCapOther.Add("gbp", value); } }

        [JsonProperty("price_hkd")]
        double? PriceHkd { get { return PriceOther["hkd"]; } set { PriceOther.Add("hkd", value); } }
        [JsonProperty("24h_volume_hkd")]
        double? Volume24hHkd { get { return Volume24hOther["hkd"]; } set { Volume24hOther.Add("hkd", value); } }
        [JsonProperty("market_cap_hkd")]
        double? MarketCapHkd { get { return MarketCapOther["hkd"]; } set { MarketCapOther.Add("hkd", value); } }

        [JsonProperty("price_idr")]
        double? PriceIdr { get { return PriceOther["idr"]; } set { PriceOther.Add("idr", value); } }
        [JsonProperty("24h_volume_idr")]
        double? Volume24hIdr { get { return Volume24hOther["idr"]; } set { Volume24hOther.Add("idr", value); } }
        [JsonProperty("market_cap_idr")]
        double? MarketCapIdr { get { return MarketCapOther["idr"]; } set { MarketCapOther.Add("idr", value); } }

        [JsonProperty("price_inr")]
        double? PriceInr { get { return PriceOther["inr"]; } set { PriceOther.Add("inr", value); } }
        [JsonProperty("24h_volume_inr")]
        double? Volume24hInr { get { return Volume24hOther["inr"]; } set { Volume24hOther.Add("inr", value); } }
        [JsonProperty("market_cap_inr")]
        double? MarketCapInr { get { return MarketCapOther["inr"]; } set { MarketCapOther.Add("inr", value); } }

        [JsonProperty("price_jpy")]
        double? PriceJpy { get { return PriceOther["jpy"]; } set { PriceOther.Add("jpy", value); } }
        [JsonProperty("24h_volume_jpy")]
        double? Volume24hJpy { get { return Volume24hOther["jpy"]; } set { Volume24hOther.Add("jpy", value); } }
        [JsonProperty("market_cap_jpy")]
        double? MarketCapJpy { get { return MarketCapOther["jpy"]; } set { MarketCapOther.Add("jpy", value); } }

        [JsonProperty("price_krw")]
        double? PriceKrw { get { return PriceOther["krw"]; } set { PriceOther.Add("krw", value); } }
        [JsonProperty("24h_volume_krw")]
        double? Volume24hKrw { get { return Volume24hOther["krw"]; } set { Volume24hOther.Add("krw", value); } }
        [JsonProperty("market_cap_krw")]
        double? MarketCapKrw { get { return MarketCapOther["krw"]; } set { MarketCapOther.Add("krw", value); } }

        [JsonProperty("price_mxn")]
        double? PriceMxn { get { return PriceOther["mxn"]; } set { PriceOther.Add("mxn", value); } }
        [JsonProperty("24h_volume_mxn")]
        double? Volume24hMxn { get { return Volume24hOther["mxn"]; } set { Volume24hOther.Add("mxn", value); } }
        [JsonProperty("market_cap_mxn")]
        double? MarketCapMxn { get { return MarketCapOther["mxn"]; } set { MarketCapOther.Add("mxn", value); } }

        [JsonProperty("price_rub")]
        double? PriceRub { get { return PriceOther["rub"]; } set { PriceOther.Add("rub", value); } }
        [JsonProperty("24h_volume_rub")]
        double? Volume24hRub { get { return Volume24hOther["rub"]; } set { Volume24hOther.Add("rub", value); } }
        [JsonProperty("market_cap_rub")]
        double? MarketCapRub { get { return MarketCapOther["rub"]; } set { MarketCapOther.Add("rub", value); } }
    }
}
