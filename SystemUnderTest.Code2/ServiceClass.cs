using System;
using System.Collections.Generic;
using System.Text;
using SystemUnderTest.Code2;

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
            var response = _http.Get(Config.ApiEndpoint).Result;
            return response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : "not successful";
        }
    }
}
