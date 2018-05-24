using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCap
{
    /// <summary>
    /// Coin Market Cap Api V2.0 Client.
    /// </summary>
    public interface ICoinMarketCapClientV2 : IDisposable
    {
        /// <summary>
        /// Lists all active cryptocurrencies.
        /// </summary>
        /// <returns>List of active cryptocurrencies.</returns>
        Task<List<Entities.ListingItem>> GetListingsAsync();

        /// <summary>
        /// Retrieves the Ticker for given cryptocurrency value.
        /// </summary>
        /// <param name="cryptoCurrencyId">The Ticker id of the required cryptocurrency.</param>
        /// <param name="convert">Convert the crypto volumes to the given currency.</param>
        /// <returns>Ticker of the requested cryptocurrency.</returns>
        Task<Entities.Ticker> GetTickerAsync(int cryptoCurrencyId, Enums.CurrenciesEnum convert);

        /// <summary>
        /// Retrieves cryptocurrency ticker data in order of rank.
        /// </summary>
        /// <param name="start">Rank start point. (Default is 1)</param>
        /// <param name="limit">Maximum of results. (default is 100, max is 100)</param>
        /// <returns>Dictionary of tickers, Key is the crypto id and the Value the ticker information.</returns>
        Task<Dictionary<int,Entities.Ticker>> GetTickerListAsync(int start, int limit);

        /// <summary>
        /// Retrieves the global market cap for crypto currencies.
        /// </summary>
        /// <param name="convert">Convert the crypto volumes to the given currency.</param>
        /// <returns>A GlobalData object with the requested information in the given currency.</returns>
        Task<Entities.GlobalData> GetGlobalDataAsync(Enums.CurrenciesEnum convert);
    }
}
