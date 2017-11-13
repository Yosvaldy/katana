using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Katana
{
    using System.IO;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080";
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started!");
                Console.ReadKey();
                Console.WriteLine("Stopping!");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }

        public class HelloWorldComponent
        {
            AppFunc _next;

            public HelloWorldComponent(AppFunc next)
            {
                _next = next;
            }

            public Task Invoke(IDictionary<string, object> enviroment)
            {
                var response = enviroment["owin.ResponseBody"] as Stream;
                using (var writer = new StreamWriter(response))
                {
                    return writer.WriteAsync("Hello!");
                }
            }
        }
    }
}
