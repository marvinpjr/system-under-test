using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemUnderTest.Code;

namespace SystemUnderTest.MyConsole
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HttpClientWrapper>().As<IHttpClientWrapper>();
            builder.RegisterType<ClientClass>().As<IClient>();
            builder.RegisterType<ServiceClass>().As<IService>();
            builder.RegisterType<System.Net.Http.HttpClient>().As<System.Net.Http.HttpClient>();
            Container = builder.Build();

            Console.WriteLine(GetString());
            Console.ReadLine();
        }

        public static string GetString()
        {
            string retval;

            using (var scope = Container.BeginLifetimeScope())
            {
                var client = scope.Resolve<IClient>();
                retval = client.GetStringFromApi();
            }

            return retval;
        }
    }
}
