using System.Net.Http;
using System.Threading.Tasks;

namespace SystemUnderTest.Code
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> Get(string url);
        Task<HttpResponseMessage> Post(string url, string json);
        Task<HttpResponseMessage> Delete(string url);
    }
}
