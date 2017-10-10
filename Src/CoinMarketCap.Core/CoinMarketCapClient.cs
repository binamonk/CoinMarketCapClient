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
    public class CoinMarketCapClient
    {
        HttpClient _client;

        static CoinMarketCapClient s_instance;

        /// <summary>
        /// Retrieves the an instance of the CoinMarketCapClient.
        /// </summary>
        /// <returns>CoinMarketCapClient instance.</returns>
        public static CoinMarketCapClient GetInstance() => s_instance = s_instance ?? new CoinMarketCapClient();

        CoinMarketCapClient()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.coinmarketcap.com/")
            };
        }

        /// <summary>
        /// Retrieves a list of Tickers.
        /// </summary>
        /// <param name="limit">Limit the amount of Tickers.</param>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns></returns>
        public async Task<List<Entities.TickerEntity>> GetTickerListAsync(int? limit = 0, Enums.ConvertEnum convert = Enums.ConvertEnum.USD)
        {
            var uri = new StringBuilder("/v1/ticker/?");
            uri.Append(limit > 0 ? $"limit={limit}&" : "");
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
    }
}
