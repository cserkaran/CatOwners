using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
//using System.Net.Http;
using System.Threading.Tasks;

namespace PetOwners.Infrastructure
{
    /// <summary>
    /// Helper methods to work with HttpClient
    /// </summary>
    public static class HttpClientHelper
    {
        /// <summary>
        /// Gets the items asynchronously from a given http url by deserializing the json response.
        /// </summary>
        /// <typeparam name="T">type of object</typeparam>
        /// <param name="path">The path.</param>
        /// <returns>Task with result as list of items requested</returns>
        public static async Task<IList<T>> GetItemsAsync<T>(string path) where T:class
        {
            HttpClient client = new HttpClient();
            IList<T> items = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<IList<T>>(jsonString);
            }
            return items;
        }
    }
}
