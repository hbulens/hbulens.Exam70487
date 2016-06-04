using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Web Api is running.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}
