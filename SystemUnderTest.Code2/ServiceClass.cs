using System;
using System.Collections.Generic;
using System.Text;

namespace SystemUnderTest.Code
{
    public class ServiceClass: IService
    {
        private IHttpClientWrapper _http;

        public ServiceClass(IHttpClientWrapper http)
        {
            _http = http;
        }

        public string GetString()
        {
            var url = "https://jsonplaceholder.typicode.com/posts";
            var response = _http.Get(url).Result;
            return response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : "not successful";
        }
    }
}
