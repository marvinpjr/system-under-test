using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUnderTest.Code2
{
    public static class Config
    {
        public static string ApiEndpoint = ConfigurationManager.AppSettings["ApiEndpoint"];
    }
}
