using hbulens.Exam70487.Wcf.Client.Inspectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerService.CustomerServiceClient client = new CustomerService.CustomerServiceClient();
            client.Endpoint.EndpointBehaviors.Add(new MyOperationBehavior());
            client.Get();

            Console.WriteLine("Press <Enter> to stop the client.");
            Console.ReadLine();
        }
    }
}
