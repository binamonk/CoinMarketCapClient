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
        public double? PriceBtc { get; set; }
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

        double? _lastUpdatedUnixTime;
        /// <summary>
        /// Last updated time in Unix time format.
        /// </summary>
        [JsonProperty("last_updated")]
        public double? LastUpdatedUnixTime {
            get => _lastUpdatedUnixTime;
            set {
                if (value != null)
                {
                    _lastUpdatedUnixTime = value;
                    _lastUpdated = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
                        .AddSeconds(value.GetValueOrDefault())
                        .ToLocalTime();
                }
            }
        }

        DateTime _lastUpdated;
        /// <summary>
        /// Last updated date.
        /// </summary>
        public DateTime LastUpdated => _lastUpdated;

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
        public double? PriceUsd
		{
			get => PriceOther.TryGetValue(ConvertEnum.USD, out double? res) ? res : null;
	        set => PriceOther.Add(ConvertEnum.USD, value);
		}
		/// <summary>
		/// Volume in the last 24 hours in USD.
		/// </summary>
		[JsonProperty("24h_volume_usd")]
        public double? Volume24hUsd {
            get => Volume24hOther.TryGetValue(ConvertEnum.USD, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.USD, value);
        }
        /// <summary>
        /// Market cap in USD.
        /// </summary>
        [JsonProperty("market_cap_usd")]
        public double? MarketCapUsd {
            get => MarketCapOther.TryGetValue(ConvertEnum.USD, out double? res) ? res : null;
			set => MarketCapOther.Add(ConvertEnum.USD, value);
        }

        [JsonProperty("price_eur")]
        double? PriceEur {
            get => PriceOther.TryGetValue(ConvertEnum.EUR, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.EUR, value);
        }
        [JsonProperty("24h_volume_eur")]
        double? Volume24hEur {
            get => Volume24hOther.TryGetValue(ConvertEnum.EUR, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.EUR, value);
        }
        [JsonProperty("market_cap_eur")]
        double? MarketCapEur {
            get => MarketCapOther.TryGetValue(ConvertEnum.EUR, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.EUR, value);
        }

        [JsonProperty("price_aud")]
        double? PriceAud {
            get => PriceOther.TryGetValue(ConvertEnum.AUD, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.AUD, value);
        }
        [JsonProperty("24h_volume_aud")]
        double? Volume24hAud {
            get => Volume24hOther.TryGetValue(ConvertEnum.AUD, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.AUD, value);
        }
        [JsonProperty("market_cap_aud")]
        double? MarketCapAud {
            get => MarketCapOther.TryGetValue(ConvertEnum.AUD, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.AUD, value);
        }

        [JsonProperty("price_brl")]
        double? PriceBrl {
            get => PriceOther.TryGetValue(ConvertEnum.BRL, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.BRL, value);
        }
        [JsonProperty("24h_volume_brl")]
        double? Volume24hBrl {
            get => Volume24hOther.TryGetValue(ConvertEnum.BRL, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.BRL, value);
        }
        [JsonProperty("market_cap_brl")]
        double? MarketCapBrl {
            get => MarketCapOther.TryGetValue(ConvertEnum.BRL, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.BRL, value);
        }

        [JsonProperty("price_cad")]
        double? PriceCad {
            get => PriceOther.TryGetValue(ConvertEnum.CAD, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.CAD, value);
        }
        [JsonProperty("24h_volume_cad")]
        double? Volume24hCad {
            get => Volume24hOther.TryGetValue(ConvertEnum.CAD, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.CAD, value);
        }
        [JsonProperty("market_cap_cad")]
        double? MarketCapCad {
            get => MarketCapOther.TryGetValue(ConvertEnum.CAD, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.CAD, value);
        }

        [JsonProperty("price_chf")]
        double? PriceChf {
            get => PriceOther.TryGetValue(ConvertEnum.CHF, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.CHF, value);
        }
        [JsonProperty("24h_volume_chf")]
        double? Volume24hChf {
			get => Volume24hOther.TryGetValue(ConvertEnum.CHF, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.CHF, value);
        }
        [JsonProperty("market_cap_chf")]
        double? MarketCapChf {
            get => MarketCapOther.TryGetValue(ConvertEnum.CHF, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.CHF, value);
        }

        [JsonProperty("price_cny")]
        double? PriceCny {
			get => PriceOther.TryGetValue(ConvertEnum.CNY, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.CNY, value);
        }
        [JsonProperty("24h_volume_cny")]
        double? Volume24hCny {
            get => Volume24hOther.TryGetValue(ConvertEnum.CNY, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.CNY, value);
        }
        [JsonProperty("market_cap_cny")]
        double? MarketCapCny {
            get => MarketCapOther.TryGetValue(ConvertEnum.CNY, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.CNY, value);
        }

        [JsonProperty("price_gbp")]
        double? PriceGbp {
            get => PriceOther.TryGetValue(ConvertEnum.GBP, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.GBP, value);
        }
        [JsonProperty("24h_volume_gbp")]
        double? Volume24hGbp {
            get => Volume24hOther.TryGetValue(ConvertEnum.GBP, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.GBP, value);
        }
        [JsonProperty("market_cap_gbp")]
        double? MarketCapGbp {
            get => MarketCapOther.TryGetValue(ConvertEnum.GBP, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.GBP, value);
        }

        [JsonProperty("price_hkd")]
        double? PriceHkd {
            get => PriceOther.TryGetValue(ConvertEnum.HKD, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.GBP, value);
        }
        [JsonProperty("24h_volume_hkd")]
        double? Volume24hHkd {
            get => Volume24hOther.TryGetValue(ConvertEnum.GBP, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.GBP, value);
        }
        [JsonProperty("market_cap_hkd")]
        double? MarketCapHkd {
            get => MarketCapOther.TryGetValue(ConvertEnum.GBP, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.GBP, value);
        }

        [JsonProperty("price_idr")]
        double? PriceIdr {
            get => PriceOther.TryGetValue(ConvertEnum.IDR, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.IDR, value);
        }
        [JsonProperty("24h_volume_idr")]
        double? Volume24hIdr {
            get => Volume24hOther.TryGetValue(ConvertEnum.IDR, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.IDR, value);
        }
        [JsonProperty("market_cap_idr")]
        double? MarketCapIdr {
            get => MarketCapOther.TryGetValue(ConvertEnum.IDR, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.IDR, value);
        }

        [JsonProperty("price_inr")]
        double? PriceInr {
            get => PriceOther.TryGetValue(ConvertEnum.INR, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.INR, value);
        }
        [JsonProperty("24h_volume_inr")]
        double? Volume24hInr {
            get => Volume24hOther.TryGetValue(ConvertEnum.INR, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.INR, value);
        }
        [JsonProperty("market_cap_inr")]
        double? MarketCapInr {
            get => MarketCapOther.TryGetValue(ConvertEnum.INR, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.INR, value);
        }

        [JsonProperty("price_jpy")]
        double? PriceJpy {
            get => PriceOther.TryGetValue(ConvertEnum.JPY, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.JPY, value);
        }
        [JsonProperty("24h_volume_jpy")]
        double? Volume24hJpy {
            get => Volume24hOther.TryGetValue(ConvertEnum.JPY, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.JPY, value);
        }
        [JsonProperty("market_cap_jpy")]
        double? MarketCapJpy {
			get => MarketCapOther.TryGetValue(ConvertEnum.JPY, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.JPY, value);
        }

        [JsonProperty("price_krw")]
        double? PriceKrw {
            get => PriceOther.TryGetValue(ConvertEnum.KRW, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.KRW, value);
        }
        [JsonProperty("24h_volume_krw")]
        double? Volume24hKrw {
            get => Volume24hOther.TryGetValue(ConvertEnum.KRW, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.KRW, value);
        }
        [JsonProperty("market_cap_krw")]
        double? MarketCapKrw {
            get => MarketCapOther.TryGetValue(ConvertEnum.KRW, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.KRW, value);
        }

        [JsonProperty("price_mxn")]
        double? PriceMxn {
            get => PriceOther.TryGetValue(ConvertEnum.MXN, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.MXN, value);
        }
        [JsonProperty("24h_volume_mxn")]
        double? Volume24hMxn {
            get => Volume24hOther.TryGetValue(ConvertEnum.MXN, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.MXN, value);
        }
        [JsonProperty("market_cap_mxn")]
        double? MarketCapMxn {
            get => MarketCapOther.TryGetValue(ConvertEnum.MXN, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.MXN, value);
        }

        [JsonProperty("price_rub")]
        double? PriceRub {
            get => PriceOther.TryGetValue(ConvertEnum.RUB, out double? res) ? res : null;
            set => PriceOther.Add(ConvertEnum.RUB, value);
        }
        [JsonProperty("24h_volume_rub")]
        double? Volume24hRub {
            get => Volume24hOther.TryGetValue(ConvertEnum.RUB, out double? res) ? res : null;
            set => Volume24hOther.Add(ConvertEnum.RUB, value);
        }
        [JsonProperty("market_cap_rub")]
        double? MarketCapRub {
            get => MarketCapOther.TryGetValue(ConvertEnum.RUB, out double? res) ? res : null;
            set => MarketCapOther.Add(ConvertEnum.RUB, value);
        }
    }
}
