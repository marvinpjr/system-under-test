using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SystemUnderTest.Code
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private HttpClient http;

        public HttpClientWrapper(HttpClient httpClient)
        {
            this.http = httpClient;
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<HttpResponseMessage> Delete(string url)
        {
            return http.DeleteAsync(url);
        }

        public Task<HttpResponseMessage> Get(string url)
        {
            return http.GetAsync(url);
        }

        public Task<HttpResponseMessage> Post(string url, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return http.PostAsync(url, content);
        }
    }
}
