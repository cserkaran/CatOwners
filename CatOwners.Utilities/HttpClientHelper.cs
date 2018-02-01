using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatOwners.Utilities
{
    public static class HttpClientHelper
    {
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
