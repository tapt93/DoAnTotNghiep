using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Framework.Common
{
    public class Utility
    {
        public static async Task<T> ExecGetDataApi<T>(string url)
        {
            //HttpClientHandler handler = new HttpClientHandler()
            //{
            //    Proxy = new WebProxy(url),
            //    UseProxy = true,
            //};
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(null);
                }
            }
        }
    }
}
