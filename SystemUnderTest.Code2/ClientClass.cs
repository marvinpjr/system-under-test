using System;

namespace SystemUnderTest.Code
{
    public class ClientClass: IClient
    {
        private IService _service;

        public ClientClass(IService service)
        {
            _service = service;
        }

        public string GetStringFromApi()
        {
            return _service.GetString();
        }
    }
}
