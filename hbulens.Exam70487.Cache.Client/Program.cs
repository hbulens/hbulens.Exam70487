using hbulens.Exam70487.Common;
using hbulens.Exam70487.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Cache.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Customer> cacheRepository = new CacheRepository<Customer>();

            bool tryAgain = true;
            do
            {
                // Add record to cache
                Console.WriteLine("Adding record to cache");
                Customer customer = new Customer() { FirstName = "Donald", LastName = "Trump" };
                cacheRepository.Create(customer);

                // Get cache items
                Console.WriteLine("Retrieving records from cache");
                IEnumerable<Customer> customers = cacheRepository.Get();
                Console.WriteLine(string.Format("Amount of items in cache: {0}", customers.Count()));

                // Remove from cache
                Console.WriteLine("Removing record from cache");
                cacheRepository.Delete(customer);
                Console.WriteLine(string.Format("Amount of items in cache: {0}", customers.Count()));

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
