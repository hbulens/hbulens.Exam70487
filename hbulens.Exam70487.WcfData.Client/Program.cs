using hbulens.Exam70487.WcfData.Client.DataService;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.WcfData.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:8083/ExamDataService");
            ExamCodeFirstContext ctx = new ExamCodeFirstContext(uri);

            bool tryAgain = true;
            do
            {
                IEnumerable<Customer> customers = ctx.Customers.ToList();
                Console.WriteLine(string.Format("Retrieved {0} customers from the WCF Data Service", customers.Count()));

                // Try replacing Id with id and see how WCF throws an excellent exception!
                DataServiceQuery<Customer> customerQuery = ctx.Customers.AddQueryOption("$filter", "Id gt 1");
                customers = customerQuery.ToList();

                Console.WriteLine(string.Format("Retrieved {0} customers from the WCF Data Service using DataServiceQuery", customers.Count()));


                Console.WriteLine("Re-run? (Y/N)");
                if (Console.ReadLine() != "Y")
                    tryAgain = false;
            }
            while (tryAgain);

            Console.WriteLine("Press <Enter> to stop the client.");
            Console.ReadLine();
        }
    }
}
