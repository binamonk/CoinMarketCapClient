using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using CoinMarketCap;
using System.Collections.Generic;

namespace CoinMarketCap.Tests
{

    [TestFixture]
    public class ClientInstancedV2Tests
    {
        readonly CoinMarketCapClientV2 _client;

        public ClientInstancedV2Tests() {
            _client = new CoinMarketCapClientV2();
        }

        [Test]
        public async Task GetListings_NoParams_Success()
        {
            var ticker = await _client.GetListingsAsync();
            Assert.IsNotNull(ticker);
            Assert.Greater(ticker.Count, 0);
        }

        [Test]
        public async Task GetTickerList_Limit10_Success()
        {
            var ticker = await _client.GetTickerListAsync(10,100);
            Assert.IsNotNull(ticker);
            Assert.AreEqual(ticker.Count(), 100);
            Assert.AreEqual(ticker.First().Value.Rank, 10);
        }

        [Test]
        public async Task GetTickerList_Rank1Limit50InEUR_Success()
        {
            var ticker = await _client.GetTickerListAsync(Enums.CurrenciesEnum.EUR, 50);
            Assert.IsNotNull(ticker);
            Assert.AreEqual(ticker.Count(), 50);
            Assert.AreEqual(ticker.First().Value.Rank, 1);
            Assert.IsNotNull(ticker.First().Value.Quotes.Keys.First().Equals(Enums.CurrenciesEnum.EUR.ToString()));
        }

        [Test]
        public async Task GetTickerList_Limit5ConvertEUR_Success()
        {
            var ticker = await _client.GetTickerListAsync(Enums.CurrenciesEnum.EUR, 5);
            Assert.IsNotNull(ticker);
            Assert.AreEqual(ticker.Count(), 5);
            Assert.Greater(ticker.First().Value.Quotes[Enums.CurrenciesEnum.EUR.ToString()].Price, 0);
        }

        [Test]
        public async Task GetTicker_BitcoinUSD_Success()
        {
            var ticker = await _client.GetTickerAsync(1, Enums.CurrenciesEnum.USD);
            Assert.IsNotNull(ticker);
            Assert.AreEqual(ticker.Id, 1);
        }

        [Test]
        public async Task GetTicker_Ethereum_Success()
        {
            var ticker = await _client.GetTickerAsync(1,Enums.CurrenciesEnum.ETH);
            Assert.IsNotNull(ticker);
            Assert.AreEqual(ticker.Quotes.First().Key, Enums.CurrenciesEnum.ETH.ToString());
        }

        [Test]
        public async Task GetTicker_Namecoin_Success()
        {
            var ticker = await _client.GetTickerAsync(3, Enums.CurrenciesEnum.USD);
            Assert.IsNotNull(ticker);
            Assert.AreEqual(ticker.Name, "Namecoin");
            Assert.Greater(ticker.Quotes[Enums.CurrenciesEnum.USD.ToString()].Price, 0);
        }

        [Test]
        public async Task GetGlobalDataAsync_Default_Success()
        {
            var globalData = await _client.GetGlobalDataAsync();
            Assert.IsNotNull(globalData);
            Assert.Greater(globalData.ActiveCryptocurrencies, 0);
        }

        [Test]
        public async Task GetGlobalDataAsync_EUR_Success()
        {
            var globalData = await _client.GetGlobalDataAsync(Enums.CurrenciesEnum.EUR);
            Assert.IsNotNull(globalData);
            Assert.IsNotNull(globalData.Quotes[Enums.CurrenciesEnum.EUR.ToString()]);
            Assert.Greater(globalData.ActiveCryptocurrencies, 0);
        }

        [Test]
        public async Task GetTickerList_All_Success()
        {
            var list = await _client.GetListingsAsync();
            var total = list.Count();
            int pages = (total % 100) > 0 ? (total / 100) + 1 : total / 100;
            Dictionary<int, Entities.Ticker> totalTickers = new Dictionary<int, Entities.Ticker>();
            for (int count = 1; count <= pages; count++)
            {
                var tickers = await _client.GetTickerListAsync(count);
                foreach (var item in tickers)
                {
                    totalTickers.Add(item.Key, item.Value);
                }
            }
            Assert.AreEqual(totalTickers.Count, total);
        }
    }
}
