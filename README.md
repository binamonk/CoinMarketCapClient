# ![CoinMarketCapLogo](https://github.com/binamonk/CoinMarketCapClient/blob/master/CoinMarketCap.png?raw=true) CoinMarketCapClient
A C# wrapper around the https://coinmarketcap.com API.

[![Build status](https://ci.appveyor.com/api/projects/status/hd01p957m0h8xnl3/branch/master?svg=true)](https://ci.appveyor.com/project/binamonk/coinmarketcapclient/branch/master) [![Codacy Badge](https://api.codacy.com/project/badge/Grade/91b2177838e74c798bf3313631657e9f)](https://www.codacy.com/app/binamonk/CoinMarketCapClient?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=binamonk/CoinMarketCapClient&amp;utm_campaign=Badge_Grade) [![NuGet](https://img.shields.io/nuget/v/CoinMarketCapClient.svg)](https://www.nuget.org/packages/CoinMarketCapClient/)
## Supported platorms:
- .NET Standard 2.0
- .NET 4.5

## Basic usage:
### Regular
```csharp
// Get instance
var client = new CoinMarketCapClient();

// Get ticker list
var tickerList = await client.GetTickerListAsync();

// Get 5 ticker items converted in Euros.
var tickerList5OnEuros = await client.GetTickerListAsync(5, CoinMarketCap.Enums.ConvertEnum.EUR);
// Read the euro value.
var value = tickerList5OnEuros.First().PriceOther[CoinMarketCap.Enums.ConvertEnum.EUR];

// Ask for bitcoin ticker.
var ticker = await client.GetTickerAsync("bitcoin");
```

### Singleton
```csharp
var client = CoinMarketCapClient.GetInstance();

// Get ticker list
var tickerList = await client.GetTickerListAsync();

// Get 5 ticker items converted in Euros.
var tickerList5OnEuros = await client.GetTickerListAsync(5, CoinMarketCap.Enums.ConvertEnum.EUR);
// Read the euro value.
var value = tickerList5OnEuros.First().PriceOther[CoinMarketCap.Enums.ConvertEnum.EUR];

// Ask for bitcoin ticker.
var ticker = await client.GetTickerAsync("bitcoin");
```

