using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Helpers
{
    public static class HttpHelper
    {
        public static async Task<T> DoGetRequestAsync<T>(string url)
        {
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.GetAsync(url).ConfigureAwait(false))
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

        public static async Task<T> DoGetRequestAsync<T>(string url, int id)
        {
            return await DoGetRequestAsync<T>(url + id).ConfigureAwait(false);
        }

        public static async Task<bool> DoPostRequestAsync(string url, object content)
        {
            using (var httpClient = new HttpClient())
            using (var stringContent = new StringContent(JsonConvert.SerializeObject(content)))
            using (var response = await httpClient.PostAsync(url, stringContent).ConfigureAwait(false))
                return response.IsSuccessStatusCode;
        }

        public static async Task<T> DoPostRequestAsync<T>(string url, object content)
        {
            using (var httpClient = new HttpClient())
            using (var stringContent = new StringContent(JsonConvert.SerializeObject(content)))
            using (var response = await httpClient.PostAsync(url, stringContent).ConfigureAwait(false))
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

        public static async Task<bool> DoPutRequestAsync(string url, int id, object content)
        {
            using (var httpClient = new HttpClient())
            using (var stringContent = new StringContent(JsonConvert.SerializeObject(content)))
            using (var response = await httpClient.PutAsync(url + id, stringContent).ConfigureAwait(false))
                return response.IsSuccessStatusCode;
        }

        public static async Task<bool> DoDeleteRequestAsync(string url, int id)
        {
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.DeleteAsync(url + id).ConfigureAwait(false))
                return response.IsSuccessStatusCode;
        }
    }
}
