using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoinMarketCap.Tests
{

    [TestFixture]
    public class ClientInstancedTests
    {
        CoinMarketCapClient _client;

        public ClientInstancedTests() {
            _client = new CoinMarketCapClient();
        }

        [Test]
        public async Task GetTickerList_NoParams_Success()
        {
            _client = CoinMarketCapClient.GetInstance();
            var ticker = await _client.GetTickerListAsync();
            Assert.IsNotNull(ticker);
            Assert.Greater(ticker.Count, 0);
            Assert.Less(ticker.First().LastUpdated, DateTime.Now);
        }

        [Test]
        public async Task GetTickerList_Limit10_Success()
        {
            _client = CoinMarketCapClient.GetInstance();
            var ticker = await _client.GetTickerListAsync(10);
            Assert.IsNotNull(ticker);
            Assert.AreEqual(ticker.Count, 10);
            Assert.Greater(ticker.First().PriceUsd, 0);
            Assert.Less(ticker.First().LastUpdated, DateTime.Now);
        }

       [Test]
        public async Task GetTickerList_Limit5ConvertEUR_Success()
        {
            _client = CoinMarketCapClient.GetInstance();
            var ticker = await _client.GetTickerListAsync(5,Enums.ConvertEnum.EUR);
            Assert.IsNotNull(ticker);
            Assert.AreEqual(ticker.Count, 5);
            Assert.Greater(ticker.First().PriceOther[Enums.ConvertEnum.EUR], 0);
            Assert.Less(ticker.First().LastUpdated, DateTime.Now);
        }

        [Test]
        public async Task GetTicker_Bitcoin_Success()
        {
            _client = CoinMarketCapClient.GetInstance();
            var ticker = await _client.GetTickerAsync("bitcoin");
            Assert.IsNotNull(ticker);
            Assert.Greater(ticker.Name, "bitcoin");
            Assert.Greater(ticker.PriceOther[Enums.ConvertEnum.USD], 0);
            Assert.Less(ticker.LastUpdated, DateTime.Now);
        }

        [Test]
        public async Task GetTicker_Ethereum_Success()
        {
            _client = CoinMarketCapClient.GetInstance();
            var ticker = await _client.GetTickerAsync("ethereum");
            Assert.IsNotNull(ticker);
            Assert.Greater(ticker.Name, "ethereum");
            Assert.Greater(ticker.PriceOther[Enums.ConvertEnum.USD], 0);
            Assert.Less(ticker.LastUpdated, DateTime.Now);
        }

        [Test]
        public async Task GetTicker_Ripple_Success()
        {
            _client = CoinMarketCapClient.GetInstance();
            var ticker = await _client.GetTickerAsync("ripple", Enums.ConvertEnum.USD);
            Assert.IsNotNull(ticker);
            Assert.Greater(ticker.Name, "ripple");
            Assert.Greater(ticker.PriceOther[Enums.ConvertEnum.USD], 0);
            Assert.Less(ticker.LastUpdated, DateTime.Now);
        }

        [Test]
        public async Task GetGlobalDataAsync_Default_Success() {
            _client = CoinMarketCapClient.GetInstance();
            var globalData = await _client.GetGlobalDataAsync();
            Assert.IsNotNull(globalData);
            Assert.Greater(globalData.MarketCapUsd, 0);
        }

        [Test]
        public async Task GetTickerList_All_Success()
        {
            _client = CoinMarketCapClient.GetInstance();
            var ticker = await _client.GetTickerListAsync(0);
            Assert.IsNotNull(ticker);
            Assert.Less(ticker.First().LastUpdated, DateTime.Now);
        }
       
    }
}
