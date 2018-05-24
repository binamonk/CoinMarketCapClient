using Newtonsoft.Json;

namespace CoinMarketCap.Entities
{
    /// <summary>
    /// Wrapper for Api V2.0 responses.
    /// </summary>
    /// <typeparam name="T">Expected data type in the Data block.</typeparam>
    public class ApiResponse<T> where T : class
    {
        /// <summary>
        /// Data recieved from the Api.
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }
        /// <summary>
        /// Details of the response.
        /// </summary>
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }
}
