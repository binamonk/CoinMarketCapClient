using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CoinMarketCap.Core;

namespace CoinMarketCap
{
    /// <summary>
    /// Coin Market Cap Api Client.
    /// </summary>
    public class CoinMarketCapClient : ICoinMarketCapClient, IDisposable
    {

        private bool _isDisposed;


        readonly HttpClient _client;

        static CoinMarketCapClient s_instance;

        /// <summary>
        /// Retrieves the an instance of the CoinMarketCapClient.
        /// </summary>
        /// <returns>CoinMarketCapClient instance.</returns>
        public static CoinMarketCapClient GetInstance() => s_instance = s_instance ?? new CoinMarketCapClient();


        /// <summary>
        /// Initializes a new instance of the CryptoCompare.CryptoCompareClient class.
        /// </summary>
        /// <param name="httpClientHandler">Custom HTTP client handler. Can be used to define proxy settigs</param>
        public CoinMarketCapClient(HttpClientHandler httpClientHandler)
        {
            if (httpClientHandler != null)
            {
                this._client = new HttpClient(httpClientHandler, true)
                {
                    BaseAddress = new Uri("https://api.coinmarketcap.com/")
                };
            }
        }

        /// <summary>
        /// Initializes a new instance of the CryptoCompare.CryptoCompareClient class.
        /// </summary>
        public CoinMarketCapClient()
            : this(new HttpClientHandler())
        {
        }

        /// <summary>
        /// Retrieves a list of Tickers.
        /// </summary>
        /// <param name="limit">Limit the amount of Tickers.</param>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns></returns>
        public async Task<List<Entities.TickerEntity>> GetTickerListAsync(int? limit = null, Enums.ConvertEnum convert = Enums.ConvertEnum.USD)
        {
            var uri = new StringBuilder("/v1/ticker/?");
            uri.Append(limit !=null ? $"limit={limit}&" : "");
            uri.Append(Enums.ConvertEnum.USD != convert ? $"convert={convert.ToString()}" : "");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<List<Entities.TickerEntity>>(response);
            return obj;
        }

        /// <summary>
        /// Retrieves the Ticker for given cryptoCurrency value.
        /// </summary>
        /// <param name="cryptoCurrency">The Ticker name of the desired cryptoCurrency.</param>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns></returns>
        public async Task<Entities.TickerEntity> GetTickerAsync(string cryptoCurrency, Enums.ConvertEnum convert = Enums.ConvertEnum.USD)
        {
            StringBuilder uri = new StringBuilder();
            uri.Append($"/v1/ticker/{cryptoCurrency}/?");
            uri.Append(Enums.ConvertEnum.USD != convert ? $"convert={convert.ToString()}" : "");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<List<Entities.TickerEntity>>(response);
            return obj.First();
        }

        /// <summary>
        /// Retrieves the global market cap for crypto currencies.
        /// </summary>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns>A GlobalDataEntity with the requested information in the given currency.</returns>
        public async Task<Entities.GlobalDataEntity> GetGlobalDataAsync(Enums.ConvertEnum convert = Enums.ConvertEnum.USD)
        {
            StringBuilder uri = new StringBuilder($"/v1/global/?");
            uri.Append(Enums.ConvertEnum.USD != convert ? $"convert={convert.ToString()}" : "");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<Entities.GlobalDataEntity>(response);
            return obj;
        }

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
