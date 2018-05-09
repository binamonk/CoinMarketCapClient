using Newtonsoft.Json;

namespace CoinMarketCap.Entities
{
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
