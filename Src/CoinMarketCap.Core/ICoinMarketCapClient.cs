using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCap.Core
{
    /// <summary>
    /// Coin Market Cap Api Client.
    /// </summary>
    public interface ICoinMarketCapClient : IDisposable
    {
        /// <summary>
        /// Retrieves a list of Tickers.
        /// </summary>
        /// <param name="limit">Limit the amount of Tickers.</param>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns></returns>
        Task<List<Entities.TickerEntity>> GetTickerListAsync(int limit, Enums.ConvertEnum convert);

        /// <summary>
        /// Retrieves the Ticker for given cryptoCurrency value.
        /// </summary>
        /// <param name="cryptoCurrency">The Ticker name of the desired cryptoCurrency.</param>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns></returns>
        Task<Entities.TickerEntity> GetTickerAsync(string cryptoCurrency, Enums.ConvertEnum convert);

        /// <summary>
        /// Retrieves the global market cap for crypto currencies.
        /// </summary>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns>A GlobalDataEntity with the requested information in the given currency.</returns>
        Task<Entities.GlobalDataEntity> GetGlobalDataAsync(Enums.ConvertEnum convert);
    }
}
