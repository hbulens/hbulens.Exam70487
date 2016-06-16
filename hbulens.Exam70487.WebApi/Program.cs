using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.SelfHost;

namespace hbulens.Exam70487.WebApi
{
    /// <summary>
    /// This project hosts the Web API. Tutorial how to set this up: http://www.asp.net/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api
    /// No elevated privileges are required although you might have to change the port.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8080/";

            // *************************************************************************************************************************
            // Start OWIN host
            // *************************************************************************************************************************           
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Web API is running at " + baseAddress);
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }

            // *************************************************************************************************************************
            // Start (obsolete) Self Host
            // To use these APIs, you need to install the following NuGet packages:
            // * Microsoft.AspNet.WebApi.SelfHost
            // * Microsoft.AspNet.Cors
            // To activate this host, comment out the code above.
            // *************************************************************************************************************************           

            HttpSelfHostConfiguration configuration = new HttpSelfHostConfiguration(baseAddress);
            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            configuration.MaxReceivedMessageSize = 1024;
            configuration.MaxBufferSize = 1024;
            configuration.MessageHandlers.Add(new CustomHeaderHandler());
            var enableCorsAttribute = new EnableCorsAttribute("*", "*", "*")
            {
                SupportsCredentials = true
            };
            configuration.EnableCors(enableCorsAttribute);

            using (var server = new HttpSelfHostServer(configuration))
            {
                Console.WriteLine("Web API is running at " + baseAddress);
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}
