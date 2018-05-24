using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoinMarketCap;
using Newtonsoft.Json;

namespace CoinMarketCap
{
    public class CoinMarketCapClientV2 : ICoinMarketCapClientV2
    {
        bool _isDisposed;
        readonly string _uri = "https://api.coinmarketcap.com/";

        readonly HttpClient _client;

        static CoinMarketCapClientV2 s_instance;

        #region Constructors
        /// <summary>
        /// Retrieves the an instance of the CoinMarketCapClientV2.
        /// </summary>
        /// <returns>CoinMarketCapClientV2 instance.</returns>
        public static CoinMarketCapClientV2 GetInstance() => s_instance = s_instance ?? new CoinMarketCapClientV2();

        /// <summary>
        /// Retrieves the an instance of the CoinMarketCapClientV2.
        /// </summary>
        /// <param name="httpClientHandler">Custom HTTP client handler. Can be used to define proxy settigs</param>
        /// <returns>CoinMarketCapClientV2 instance.</returns>
        public static CoinMarketCapClientV2 GetInstance(HttpClientHandler httpClientHandler) =>
            s_instance = s_instance ?? new CoinMarketCapClientV2(httpClientHandler);

        /// <summary>
        /// Initializes a new instance of the CoinMarketCapClientV2 class.
        /// </summary>
        /// <param name="httpClientHandler">Custom HTTP client handler. Can be used to define proxy settigs.</param>
        public CoinMarketCapClientV2(HttpClientHandler httpClientHandler)
        {
            if (httpClientHandler != null)
            {
                this._client = new HttpClient(httpClientHandler, true)
                {
                    BaseAddress = new Uri(_uri)
                };
            }
        }

        /// <summary>
        /// Initializes a new instance of the CoinMarketCapClient class.
        /// </summary>
        public CoinMarketCapClientV2()
            : this(new HttpClientHandler())
        {
        }
        #endregion

        /// <summary>
        /// Lists all active cryptocurrencies.
        /// </summary>
        /// <returns>List of active cryptocurrencies.</returns>
        public async Task<List<Entities.ListingItem>> GetListingsAsync()
        {
            var uri = new StringBuilder("/v2/listings/");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<Entities.ApiResponse<List<Entities.ListingItem>>>(response);
            return obj.Data;
        }

        #region Get Ticker List
        /// <summary>
        /// Retrieves cryptocurrency ticker data in order of rank.
        /// </summary>
        /// <param name="start">Rank start point. (Default is 1)</param>
        /// <param name="limit">Maximum of results. (default is 100, max is 100)</param>
        /// <param name="convert">Return pricing info in terms of another currency.</param>
        /// <returns>Dictionary of tickers, Key is the crypto id and the Value the ticker information.</returns>
        async Task<Dictionary<int, Entities.Ticker>> GetTickerListAsync(int? start, int? limit, Enums.CurrenciesEnum? convert)
        {
            var uri = new StringBuilder("/v2/ticker/?");
            if (start != null)
            {
                uri.Append($"start={start}&");
            }
            if (convert != null)
            {
                uri.Append($"convert={convert.ToString()}&");
            }
            if (limit != null)
            {
                uri.Append($"limit={limit}");
            }
            System.Diagnostics.Debug.WriteLine($"{_client.BaseAddress}{uri.ToString()}");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<Entities.ApiResponse<Dictionary<int, Entities.Ticker>>>(response);
            return obj.Data;
        }

        /// <summary>
        /// Retrieves cryptocurrency ticker data in order of rank and in USD currency.
        /// </summary>
        /// <param name="start">Rank start point. (Default is 1)</param>
        /// <param name="limit">Maximum of results. (default is 100, max is 100)</param>
        /// <returns>Dictionary of tickers, Key is the crypto id and the Value the ticker information.</returns>
        public async Task<Dictionary<int, Entities.Ticker>> GetTickerListAsync(int start, int limit) =>
            await GetTickerListAsync(start, limit, Enums.CurrenciesEnum.USD);

        /// <summary>
        /// Retrieves cryptocurrency ticker data in order of rank.
        /// </summary>
        /// <param name="convert">Return pricing info in terms of another currency.</param>
        /// <param name="limit">Maximum of results. (default is 100, max is 100)</param>
        /// <returns>Dictionary of tickers, Key is the crypto id and the Value the ticker information.</returns>
        public async Task<Dictionary<int, Entities.Ticker>> GetTickerListAsync(Enums.CurrenciesEnum convert, int limit) =>
            await GetTickerListAsync(null, limit, convert);

        /// <summary>
        /// Retrieves cryptocurrency ticker data in order of rank in USD currency.
        /// </summary>
        /// <param name="limit">Maximum of results. (default is 100, max is 100)</param>
        /// <returns>Dictionary of tickers, Key is the crypto id and the Value the ticker information.</returns>
        public async Task<Dictionary<int, Entities.Ticker>> GetTickerListAsync(int limit) =>
            await GetTickerListAsync(null, limit, null);

        /// <summary>
        /// Retrieves top 100 cryptocurrencies ticker data in order of rank.
        /// </summary>
        /// <param name="convert">Return pricing info in terms of another currency.</param>
        /// <returns>Dictionary of tickers, Key is the crypto id and the Value the ticker information.</returns>
        public async Task<Dictionary<int, Entities.Ticker>> GetTickerListAsync(Enums.CurrenciesEnum convert) =>
            await GetTickerListAsync(null, 100, convert);

        #endregion

        #region Get Ticker
        /// <summary>
        /// Retrieves the Ticker for given cryptocurrency value.
        /// </summary>
        /// <param name="cryptoCurrencyId">The Ticker id of the required cryptocurrency.</param>
        /// <param name="convert">Convert the crypto volumes to the given currency.</param>
        /// <returns>Ticker of the requested cryptocurrency.</returns>
        public async Task<Entities.Ticker> GetTickerAsync(int cryptoCurrencyId, Enums.CurrenciesEnum convert)
        {
            var uri = new StringBuilder($"/v2/ticker/{cryptoCurrencyId}/?");
            uri.Append($"convert={convert.ToString()}");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<Entities.ApiResponse<Entities.Ticker>>(response);
            return obj.Data;
        }

        /// <summary>
        /// Retrieves the Ticker for given cryptocurrency value with volumes in USD currency.
        /// </summary>
        /// <param name="cryptoCurrencyId">The Ticker id of the required cryptocurrency.</param>
        /// <returns>Ticker of the requested cryptocurrency.</returns>
        public async Task<Entities.Ticker> GetTickerAsync(int cryptoCurrencyId) =>
            await GetTickerAsync(cryptoCurrencyId, Enums.CurrenciesEnum.USD);
        #endregion

        #region Get Global Data
        /// <summary>
        /// Retrieves the global market cap for crypto currencies.
        /// </summary>
        /// <param name="convert">Convert the crypto volumes to the given currency.</param>
        /// <returns>A GlobalData object with the requested information in the given currency.</returns>
        public async Task<Entities.GlobalData> GetGlobalDataAsync(Enums.CurrenciesEnum convert)
        {
            var uri = new StringBuilder("/v2/global/?");
            uri.Append($"convert={convert.ToString()}");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<Entities.ApiResponse<Entities.GlobalData>>(response);
            return obj.Data;

        }

        /// <summary>
        /// Retrieves the global market cap for crypto currencies with volumes in USD.
        /// </summary>
        /// <returns>A GlobalData object with the requested information in USD.</returns>
        public async Task<Entities.GlobalData> GetGlobalDataAsync() =>
            await GetGlobalDataAsync(Enums.CurrenciesEnum.USD);
        #endregion

        #region IDisposable Implementation
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to
        /// release only unmanaged resources.</param>
        internal virtual void Dispose(bool disposing)
        {
            if (!this._isDisposed)
            {
                if (disposing)
                {
                    this._client?.Dispose();
                }
                this._isDisposed = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        /// <seealso cref="M:System.IDisposable.Dispose()"/>
        public void Dispose() => this.Dispose(true);
        #endregion
    }
}
