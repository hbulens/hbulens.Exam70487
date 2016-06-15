using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using hbulens.Exam70487.Common;

namespace hbulens.Exam70487.WebApi.Client
{
    class Program
    {
        private const string _baseUri = "http://localhost:8080/api/";
        static void Main(string[] args)
        {
            Console.Title = "Web API Test Client";

            Console.WriteLine("*****************************");
            Console.WriteLine("HTTP GET Customers");
            Console.WriteLine("*****************************");

            Get();

            Console.WriteLine("*****************************");
            Console.WriteLine("HTTP POST Customers");
            Console.WriteLine("*****************************");

            Post();

            Console.WriteLine("*****************************");
            Console.WriteLine("HTTP PATCH Customers");
            Console.WriteLine("*****************************");

            Patch();

            Console.WriteLine("*****************************");
            Console.WriteLine("HTTP PUT Customers");
            Console.WriteLine("*****************************");

            Put();

            Console.WriteLine("*****************************");
            Console.WriteLine("HTTP DELETE Customers");
            Console.WriteLine("*****************************");

            Delete();

            Console.WriteLine("Press <Enter> to stop the client.");
            Console.ReadLine();
        }

        private static void Get()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_baseUri);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Task<HttpResponseMessage> responseMessageTask = Task<HttpResponseMessage>.Run(async () => await httpClient.GetAsync("Customers/Get"));
                    HttpResponseMessage responseMessage = responseMessageTask.Result;
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        // Note that the ReadAsAsync extension method is in the System.Net.Http.Formatting namespace and resides in the Microsoft.AspNet.WebApi.Client NuGet package
                        Task<IEnumerable<Customer>> customersTask = Task<Customer>.Run(async () => await responseMessage.Content.ReadAsAsync<IEnumerable<Customer>>());
                        IEnumerable<Customer> customers = customersTask.Result;

                        if (customers != null)
                        {
                            Console.WriteLine($"Customers: {string.Join(", ", customers.Select(x => x.Name).ToArray())}");
                        }
                    }
                }
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        private static void Post()
        {
            try
            {

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Put()
        {
            try
            {

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Patch()
        {
            try
            {

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Delete()
        {
            try
            {

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
