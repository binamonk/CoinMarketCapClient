using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCap
{
    /// <summary>
    /// Coin Market Cap Api Client.
    /// </summary>
    public interface ICoinMarketCapClientV2 : IDisposable
    {
        /// <summary>
        /// Displays all active cryptocurrency listings.
        /// </summary>
        /// <returns></returns>
        Task<List<Entities.ListingItem>> GetListingsAsync();

        /// <summary>
        /// Retrieves the Ticker for given cryptoCurrency value.
        /// </summary>
        /// <param name="cryptoCurrencyId">The Ticker name of the desired cryptoCurrency.</param>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns></returns>
        Task<Entities.TickerEntity> GetTickerAsync(int cryptoCurrencyId, Enums.ConvertEnum convert);

        /// <summary>
        /// Retrieves the global market cap for crypto currencies.
        /// </summary>
        /// <param name="convert">Convert the crypto volumes to the given Fiat currency.</param>
        /// <returns>A GlobalDataEntity with the requested information in the given currency.</returns>
        Task<Entities.ApiResponse<List<Entities.GlobalData>>> GetGlobalDataAsync(Enums.ConvertEnum convert);
    }
}
