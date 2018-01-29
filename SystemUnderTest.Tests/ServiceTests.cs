using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SystemUnderTest.Code;
using SystemUnderTest.Code2;

namespace SystemUnderTest.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private static TestContext _context;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _context = context;
        }

        [TestMethod]
        public void CanFakeMyHttpClient()
        {
            // Arrange            
            var fakeHttpClientWrapper = A.Fake<IHttpClientWrapper>();
            var TestResults = "Fake Response Data for Test";

            A.CallTo(() => fakeHttpClientWrapper.Get(A<string>.That.Matches(s => s == Config.ApiEndpoint)))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(TestResults)
                }));
            var client = new ClientClass(new ServiceClass(fakeHttpClientWrapper));

            // Act
            var result = client.GetStringFromApi();

            // Assert
            Assert.AreEqual(TestResults, result);
        }
    }
}
