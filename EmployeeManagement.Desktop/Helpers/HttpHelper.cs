using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Desktop.Helpers
{
    public class HttpHelper
    {
        private static HttpHelper instance;
        private static readonly object locker = new object();
        public static HttpHelper Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new HttpHelper();
                    return instance;
                }
            }
        }

        private HttpHelper() { }

        public async Task<T> DoGetRequestAsync<T>(string url)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                return default;
            }
        }

        public async Task<T> DoGetRequestAsync<T>(string url, int id)
        {
            return await DoGetRequestAsync<T>(url + id);
        }

        public async Task<bool> DoPostRequestAsync(string url, object content)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(content))).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DoPutRequestAsync(string url, int id, object content)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.PutAsync(url + id, new StringContent(JsonConvert.SerializeObject(content))).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DoDeleteRequestAsync(string url, int id)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.DeleteAsync(url + id).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}
