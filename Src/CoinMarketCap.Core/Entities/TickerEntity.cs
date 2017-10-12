using CoinMarketCap.Enums;
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
        /// <summary>
        /// Crypto Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Crypto Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Crypto Symbol.
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// Rank.
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// Price in BTC.
        /// </summary>
        [JsonProperty("price_btc")]
        public double PriceBtc { get; set; }
        /// <summary>
        /// Available Supply.
        /// </summary>
        [JsonProperty("available_supply")]
        public double? AvailableSupply { get; set; }
        /// <summary>
        /// Total Supply.
        /// </summary>
        [JsonProperty("total_supply")]
        public double? TotalSupply { get; set; }
        /// <summary>
        /// Percentage change in the last hour.
        /// </summary>
        [JsonProperty("percent_change_1h")]
        public double? PercentChange1h { get; set; }
        /// <summary>
        /// Percentage change in the las 24 hours.
        /// </summary>
        [JsonProperty("percent_change_24h")]
        public double? PercentChange24h { get; set; }
        /// <summary>
        /// Percentage change in the last 7 days.
        /// </summary>
        [JsonProperty("percent_change_7d")]
        public double? PercentChange7d { get; set; }

        double _lastUpdatedUnixTime;
        /// <summary>
        /// Last updated time in Unix time format.
        /// </summary>
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
        /// <summary>
        /// Last updated date.
        /// </summary>
        public DateTime LastUpdated { get { return _lastUpdated; } }
        /// <summary>
        /// Price in the given Fiat currency.
        /// </summary>
        public Dictionary<ConvertEnum, double?> PriceOther { get; set; } = new Dictionary<ConvertEnum, double?>();
        /// <summary>
        /// Volume in the las 24 in the given Fiat currency.
        /// </summary>
        public Dictionary<ConvertEnum, double?> Volume24hOther { get; set; } = new Dictionary<ConvertEnum, double?>();
        /// <summary>
        /// Market cap in the given Fiat currency.
        /// </summary>
        public Dictionary<ConvertEnum, double?> MarketCapOther { get; set; } = new Dictionary<ConvertEnum, double?>();

        /// <summary>
        /// Price in USD.
        /// </summary>
        [JsonProperty("price_usd")]
        public double PriceUsd { get { return PriceOther[ConvertEnum.USD].Value; } set { PriceOther.Add(ConvertEnum.USD, value); } }
        /// <summary>
        /// Volume in the last 24 hours in USD.
        /// </summary>
        [JsonProperty("24h_volume_usd")]
        public double? Volume24hUsd { get { return Volume24hOther[ConvertEnum.USD].Value; } set { Volume24hOther.Add(ConvertEnum.USD, value); } }
        /// <summary>
        /// Market cap in USD.
        /// </summary>
        [JsonProperty("market_cap_usd")]
        public double? MarketCapUsd { get { return MarketCapOther[ConvertEnum.USD].Value; } set { MarketCapOther.Add(ConvertEnum.USD, value); } }

        [JsonProperty("price_eur")]
        double? PriceEur { get { return PriceOther[ConvertEnum.EUR]; } set { PriceOther.Add(ConvertEnum.EUR, value); } }
        [JsonProperty("24h_volume_eur")]
        double? Volume24hEur { get { return Volume24hOther[ConvertEnum.EUR]; } set { Volume24hOther.Add(ConvertEnum.EUR, value); } }
        [JsonProperty("market_cap_eur")]
        double? MarketCapEur { get { return MarketCapOther[ConvertEnum.EUR]; } set { MarketCapOther.Add(ConvertEnum.EUR, value); } }

        [JsonProperty("price_aud")]
        double? PriceAud { get { return PriceOther[ConvertEnum.AUD]; } set { PriceOther.Add(ConvertEnum.AUD, value); } }
        [JsonProperty("24h_volume_aud")]
        double? Volume24hAud { get { return Volume24hOther[ConvertEnum.AUD]; } set { Volume24hOther.Add(ConvertEnum.AUD, value); } }
        [JsonProperty("market_cap_aud")]
        double? MarketCapAud { get { return MarketCapOther[ConvertEnum.AUD]; } set { MarketCapOther.Add(ConvertEnum.AUD, value); } }

        [JsonProperty("price_brl")]
        double? PriceBrl { get { return PriceOther[ConvertEnum.BRL]; } set { PriceOther.Add(ConvertEnum.BRL, value); } }
        [JsonProperty("24h_volume_brl")]
        double? Volume24hBrl { get { return Volume24hOther[ConvertEnum.BRL]; } set { Volume24hOther.Add(ConvertEnum.BRL, value); } }
        [JsonProperty("market_cap_brl")]
        double? MarketCapBrl { get { return MarketCapOther[ConvertEnum.BRL]; } set { MarketCapOther.Add(ConvertEnum.BRL, value); } }

        [JsonProperty("price_cad")]
        double? PriceCad { get { return PriceOther[ConvertEnum.CAD]; } set { PriceOther.Add(ConvertEnum.CAD, value); } }
        [JsonProperty("24h_volume_cad")]
        double? Volume24hCad { get { return Volume24hOther[ConvertEnum.CAD]; } set { Volume24hOther.Add(ConvertEnum.CAD, value); } }
        [JsonProperty("market_cap_cad")]
        double? MarketCapCad { get { return MarketCapOther[ConvertEnum.CAD]; } set { MarketCapOther.Add(ConvertEnum.CAD, value); } }

        [JsonProperty("price_chf")]
        double? PriceChf { get { return PriceOther[ConvertEnum.CHF]; } set { PriceOther.Add(ConvertEnum.CHF, value); } }
        [JsonProperty("24h_volume_chf")]
        double? Volume24hChf { get { return Volume24hOther[ConvertEnum.CHF]; } set { Volume24hOther.Add(ConvertEnum.CHF, value); } }
        [JsonProperty("market_cap_chf")]
        double? MarketCapChf { get { return MarketCapOther[ConvertEnum.CHF]; } set { MarketCapOther.Add(ConvertEnum.CHF, value); } }

        [JsonProperty("price_cny")]
        double? PriceCny { get { return PriceOther[ConvertEnum.CNY]; } set { PriceOther.Add(ConvertEnum.CNY, value); } }
        [JsonProperty("24h_volume_cny")]
        double? Volume24hCny { get { return Volume24hOther[ConvertEnum.CNY]; } set { Volume24hOther.Add(ConvertEnum.CNY, value); } }
        [JsonProperty("market_cap_cny")]
        double? MarketCapCny { get { return MarketCapOther[ConvertEnum.CNY]; } set { MarketCapOther.Add(ConvertEnum.CNY, value); } }

        [JsonProperty("price_gbp")]
        double? PriceGbp { get { return PriceOther[ConvertEnum.GBP]; } set { PriceOther.Add(ConvertEnum.GBP, value); } }
        [JsonProperty("24h_volume_gbp")]
        double? Volume24hGbp { get { return Volume24hOther[ConvertEnum.GBP]; } set { Volume24hOther.Add(ConvertEnum.GBP, value); } }
        [JsonProperty("market_cap_gbp")]
        double? MarketCapGbp { get { return MarketCapOther[ConvertEnum.GBP]; } set { MarketCapOther.Add(ConvertEnum.GBP, value); } }

        [JsonProperty("price_hkd")]
        double? PriceHkd { get { return PriceOther[ConvertEnum.HKD]; } set { PriceOther.Add(ConvertEnum.GBP, value); } }
        [JsonProperty("24h_volume_hkd")]
        double? Volume24hHkd { get { return Volume24hOther[ConvertEnum.GBP]; } set { Volume24hOther.Add(ConvertEnum.GBP, value); } }
        [JsonProperty("market_cap_hkd")]
        double? MarketCapHkd { get { return MarketCapOther[ConvertEnum.GBP]; } set { MarketCapOther.Add(ConvertEnum.GBP, value); } }

        [JsonProperty("price_idr")]
        double? PriceIdr { get { return PriceOther[ConvertEnum.IDR]; } set { PriceOther.Add(ConvertEnum.IDR, value); } }
        [JsonProperty("24h_volume_idr")]
        double? Volume24hIdr { get { return Volume24hOther[ConvertEnum.IDR]; } set { Volume24hOther.Add(ConvertEnum.IDR, value); } }
        [JsonProperty("market_cap_idr")]
        double? MarketCapIdr { get { return MarketCapOther[ConvertEnum.IDR]; } set { MarketCapOther.Add(ConvertEnum.IDR, value); } }

        [JsonProperty("price_inr")]
        double? PriceInr { get { return PriceOther[ConvertEnum.INR]; } set { PriceOther.Add(ConvertEnum.INR, value); } }
        [JsonProperty("24h_volume_inr")]
        double? Volume24hInr { get { return Volume24hOther[ConvertEnum.INR]; } set { Volume24hOther.Add(ConvertEnum.INR, value); } }
        [JsonProperty("market_cap_inr")]
        double? MarketCapInr { get { return MarketCapOther[ConvertEnum.INR]; } set { MarketCapOther.Add(ConvertEnum.INR, value); } }

        [JsonProperty("price_jpy")]
        double? PriceJpy { get { return PriceOther[ConvertEnum.JPY]; } set { PriceOther.Add(ConvertEnum.JPY, value); } }
        [JsonProperty("24h_volume_jpy")]
        double? Volume24hJpy { get { return Volume24hOther[ConvertEnum.JPY]; } set { Volume24hOther.Add(ConvertEnum.JPY, value); } }
        [JsonProperty("market_cap_jpy")]
        double? MarketCapJpy { get { return MarketCapOther[ConvertEnum.JPY]; } set { MarketCapOther.Add(ConvertEnum.JPY, value); } }

        [JsonProperty("price_krw")]
        double? PriceKrw { get { return PriceOther[ConvertEnum.KRW]; } set { PriceOther.Add(ConvertEnum.KRW, value); } }
        [JsonProperty("24h_volume_krw")]
        double? Volume24hKrw { get { return Volume24hOther[ConvertEnum.KRW]; } set { Volume24hOther.Add(ConvertEnum.KRW, value); } }
        [JsonProperty("market_cap_krw")]
        double? MarketCapKrw { get { return MarketCapOther[ConvertEnum.KRW]; } set { MarketCapOther.Add(ConvertEnum.KRW, value); } }

        [JsonProperty("price_mxn")]
        double? PriceMxn { get { return PriceOther[ConvertEnum.MXN]; } set { PriceOther.Add(ConvertEnum.MXN, value); } }
        [JsonProperty("24h_volume_mxn")]
        double? Volume24hMxn { get { return Volume24hOther[ConvertEnum.MXN]; } set { Volume24hOther.Add(ConvertEnum.MXN, value); } }
        [JsonProperty("market_cap_mxn")]
        double? MarketCapMxn { get { return MarketCapOther[ConvertEnum.MXN]; } set { MarketCapOther.Add(ConvertEnum.MXN, value); } }

        [JsonProperty("price_rub")]
        double? PriceRub { get { return PriceOther[ConvertEnum.RUB]; } set { PriceOther.Add(ConvertEnum.RUB, value); } }
        [JsonProperty("24h_volume_rub")]
        double? Volume24hRub { get { return Volume24hOther[ConvertEnum.RUB]; } set { Volume24hOther.Add(ConvertEnum.RUB, value); } }
        [JsonProperty("market_cap_rub")]
        double? MarketCapRub { get { return MarketCapOther[ConvertEnum.RUB]; } set { MarketCapOther.Add(ConvertEnum.RUB, value); } }
    }
}
