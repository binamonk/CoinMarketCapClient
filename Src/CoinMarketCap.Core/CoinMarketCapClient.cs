using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CoinMarketCap
{
    /// <summary>
    /// Coin Market Cap Api Client.
    /// </summary>
    [Obsolete("Public API Version 1 will be taken offline on November 30th, 2018. Please modify your application to use Version 2 prior to shutdown.")]
    public class CoinMarketCapClient : ICoinMarketCapClient, IDisposable
    {

        bool _isDisposed;
        readonly string _uri = "https://api.coinmarketcap.com/";

        readonly HttpClient _client;

        static CoinMarketCapClient s_instance;

        #region Constructors
        /// <summary>
        /// Retrieves the an instance of the CoinMarketCapClient.
        /// </summary>
        /// <returns>CoinMarketCapClient instance.</returns>
        public static CoinMarketCapClient GetInstance() => s_instance = s_instance ?? new CoinMarketCapClient();

        /// <summary>
        /// Retrieves the an instance of the CoinMarketCapClient.
        /// </summary>
        /// <param name="httpClientHandler">Custom HTTP client handler. Can be used to define proxy settigs</param>
        /// <returns>CoinMarketCapClient instance.</returns>
        public static CoinMarketCapClient GetInstance(HttpClientHandler httpClientHandler) => 
            s_instance = s_instance ?? new CoinMarketCapClient(httpClientHandler);

        /// <summary>
        /// Initializes a new instance of the CoinMarketCapClient class.
        /// </summary>
        /// <param name="httpClientHandler">Custom HTTP client handler. Can be used to define proxy settigs.</param>
        public CoinMarketCapClient(HttpClientHandler httpClientHandler)
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
		public CoinMarketCapClient()
            : this(new HttpClientHandler())
        {
        }
        #endregion

        #region GetTickerList
        /// <summary>
        /// Retrieves a list of Tickers.
        /// </summary>
        /// <param name="limit">Limit the amount of Tickers.</param>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns>Returns the ticker list with their volumes.</returns>
        public async Task<List<Entities.TickerEntity>> GetTickerListAsync(int limit, Enums.ConvertEnum convert)
        {
            var uri = new StringBuilder("/v1/ticker/?");
            uri.Append($"limit={limit}&");
            uri.Append($"convert={convert.ToString()}");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<List<Entities.TickerEntity>>(response);
            return obj;
        }

        /// <summary>
        /// Retrieves a list of Tickers.
        /// </summary>
        /// <param name="limit">Limit the amount of Tickers.</param>
        /// <returns>Returns the ticker list with their volumes in USD.</returns>
        public async Task<List<Entities.TickerEntity>> GetTickerListAsync(int limit) => 
            await GetTickerListAsync(limit, Enums.ConvertEnum.USD).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a list of Tickers.
        /// </summary>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns>Returns all available tickers with their volumes.</returns>
        public async Task<List<Entities.TickerEntity>> GetTickerListAsync(Enums.ConvertEnum convert) => 
            await GetTickerListAsync(0, convert).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a list of Tickers
        /// </summary>
        /// <returns>Returns all available tickers with their volumes in USD.</returns>
        public async Task<List<Entities.TickerEntity>> GetTickerListAsync() => 
            await GetTickerListAsync(0, Enums.ConvertEnum.USD).ConfigureAwait(false);
        #endregion

        #region GetTicker
        /// <summary>
        /// Retrieves the Ticker for given cryptoCurrency value.
        /// </summary>
        /// <param name="cryptoCurrency">The Ticker name of the desired cryptoCurrency.</param>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns>Returns the ticker.</returns>
        public async Task<Entities.TickerEntity> GetTickerAsync(string cryptoCurrency, Enums.ConvertEnum convert)
        {
            StringBuilder uri = new StringBuilder();
            uri.Append($"/v1/ticker/{cryptoCurrency}/?");
            uri.Append(Enums.ConvertEnum.USD != convert ? $"convert={convert.ToString()}" : "");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<List<Entities.TickerEntity>>(response);
            return obj.First();
        }

        /// <summary>
        /// Retrieves the Ticker for given cryptoCurrency value.
        /// </summary>
        /// <param name="cryptoCurrency">The Ticker name of the desired cryptoCurrency.</param>
        /// <returns>Returns the ticker in USD.</returns>
        public async Task<Entities.TickerEntity> GetTickerAsync(string cryptoCurrency) => 
            await GetTickerAsync(cryptoCurrency, Enums.ConvertEnum.USD).ConfigureAwait(false);

        #endregion

        #region GetlGlobalData
        /// <summary>
        /// Retrieves the global market cap for crypto currencies.
        /// </summary>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns>A GlobalDataEntity with the requested information in the given currency.</returns>
        public async Task<Entities.GlobalDataEntity> GetGlobalDataAsync(Enums.ConvertEnum convert)
        {
            StringBuilder uri = new StringBuilder($"/v1/global/?");
            uri.Append(Enums.ConvertEnum.USD != convert ? $"convert={convert.ToString()}" : "");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<Entities.GlobalDataEntity>(response);
            return obj;
        }

        /// <summary>
        /// Retrieves the global market cap for crypto currencies.
        /// </summary>
        /// <returns>A GlobalDataEntity with the requested information in USD.</returns>
        public async Task<Entities.GlobalDataEntity> GetGlobalDataAsync() =>
            await GetGlobalDataAsync(Enums.ConvertEnum.USD).ConfigureAwait(false);
        #endregion

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
    }
}
