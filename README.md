# ![CoinMarketCapLogo](https://github.com/binamonk/CoinMarketCapClient/blob/master/CoinMarketCap.png?raw=true) CoinMarketCapClient
A C# wrapper around the https://coinmarketcap.com API.
## Available for:
- .NET Standard 2.0
- .NET 4.5

## Example:
```csharp
	// Get the instance
	var client = CoinMarketCapClient.GetInstance();
    
    // Get ticker list
	var tickerList = await client.GetTickerListAsync();
    
    // Get 5 ticker items converted in Euros.
    var tickerList5OnEuros = await client.GetTickerListAsync(5,Enums.ConvertEnum.EUR);
    // Read the euro value.
    var value = tickerList50OnEuros.First().PriceOther[Enums.ConvertEnum.EUR];
    
    // Ask for bitcoin ticker.
    var ticker = await client.GetTickerAsync("bitcoin");
```

