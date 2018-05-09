using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoinMarketCap.Entities;
using CoinMarketCap.Enums;
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
        /// Retrieves the an instance of the CoinMarketCapClient.
        /// </summary>
        /// <returns>CoinMarketCapClient instance.</returns>
        public static CoinMarketCapClientV2 GetInstance() => s_instance = s_instance ?? new CoinMarketCapClientV2();

        /// <summary>
        /// Retrieves the an instance of the CoinMarketCapClient.
        /// </summary>
        /// <param name="httpClientHandler">Custom HTTP client handler. Can be used to define proxy settigs</param>
        /// <returns>CoinMarketCapClient instance.</returns>
        public static CoinMarketCapClientV2 GetInstance(HttpClientHandler httpClientHandler) =>
            s_instance = s_instance ?? new CoinMarketCapClientV2(httpClientHandler);

        /// <summary>
        /// Initializes a new instance of the CoinMarketCapClient class.
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
        /// Displays all active cryptocurrency listings.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ListingItem>> GetListingsAsync()
        {
            var uri = new StringBuilder("/v2/listings/");
            var response = await _client.GetStringAsync(uri.ToString());
            var obj = JsonConvert.DeserializeObject<ApiResponse<List<ListingItem>>>(response);
            return obj.Data;

        }

        public Task<ApiResponse<List<GlobalData>>> GetGlobalDataAsync(ConvertEnum convert)
        {
            throw new NotImplementedException();
        }

        public Task<TickerEntity> GetTickerAsync(string cryptoCurrency, ConvertEnum convert)
        {
            throw new NotImplementedException();
        }

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
