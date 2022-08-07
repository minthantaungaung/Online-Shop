using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShopWeb.ApiRepo
{
    public class ApiRequest<T>
    {
        public static string GetConnectionString()
        {
            return Startup.ConnectionString;
        }
        static string BaseUrl = GetConnectionString();
        public static async Task<T> Get(string url)
        {
            url = BaseUrl + url;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await client.GetAsync(string.Format(url)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);

                            return jsonContent;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
            catch
            {
                return default(T);
            }
        }
        public static async Task<T> Post(string url, T entity)
        {
            url = BaseUrl + url;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var content = new StringContent(JsonConvert.SerializeObject(entity), UTF8Encoding.UTF8, "application/json"))
                {
                    using (var response = await client.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);
                            return jsonContent;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
        }
    }
}
