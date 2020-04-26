using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ApiUtility
{
    public class HttpHelper
    {        
        public Dictionary<String, String> Headers { get; set; } = new Dictionary<String, String>()
        {
            { "User-Agent", "Awesome-Octocat-App"}
        };

        public T Get<T>(String url)
        {
            return Send<T>(url, HttpMethod.Get);
        }

        public T Put<T>(String url, Object data)
        {
            return Send<T>(url, HttpMethod.Put, data);
        }

        public T Post<T>(String url, Object data)
        {
            return Send<T>(url, HttpMethod.Post, data);
        }

        private T Send<T>(String url, HttpMethod method, Object data = null)
        {
            using (HttpClient http = new HttpClient())
            using (HttpRequestMessage request = new HttpRequestMessage(method, url))
            {
                AddHeaders(request);

                AddContent(request, data);

                //send
                using (HttpResponseMessage response = http.SendAsync(request).GetAwaiter().GetResult())
                {
                    //read responce
                    String stringResponse = response.Content?.ReadAsStringAsync().GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        return GetResponseObject<T>(stringResponse);
                    }
                    else
                    {
                        throw new Exception($"Code: {response.StatusCode}, Error: {stringResponse}");
                    }
                }
            }
        }

        private static T GetResponseObject<T>(String stringResponse)
        {
            Type type = typeof(T);

            if (type == typeof(String))
            {
                return (T)Convert.ChangeType(stringResponse, type);
            }

            return JsonConvert.DeserializeObject<T>(stringResponse);
        }

        private void AddHeaders(HttpRequestMessage request)
        {
            if (Headers?.Count > 0)
            {
                foreach (var header in Headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
        }

        private void AddContent(HttpRequestMessage request, Object data)
        {
            if (data != null)
            {
                request.Content = GetStringContent(data);
            }
        }

        private StringContent GetStringContent(Object data)
        {
            String stringData = JsonConvert.SerializeObject(data);
            return new StringContent(stringData, Encoding.UTF8, "application/json");
        }
    }
}
