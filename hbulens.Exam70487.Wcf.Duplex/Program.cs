using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Duplex
{
    class Program
    {
        static void Main(string[] args)
        {     
            using (ServiceHost host = new ServiceHost(typeof(DuplexService)))
            {                          
                Uri baseHttpAddress = new Uri("http://localhost:8080/Duplex");                          
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseHttpAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }

        }
    }
}
