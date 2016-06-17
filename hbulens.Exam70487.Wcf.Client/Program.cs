using hbulens.Exam70487.Wcf.Client.CustomerService;
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
            // BasicHttpBinding
            CustomerServiceClient basicHttpBindingClient = new CustomerServiceClient("BasicHttpBinding_ICustomerService");
            basicHttpBindingClient.Endpoint.EndpointBehaviors.Add(new MyOperationBehavior());
            Customer[] basicHttpCustomers = basicHttpBindingClient.Get();

            // WSHttpBinding
            CustomerServiceClient wsHttpBindingClient = new CustomerServiceClient("WSHttpBinding_ICustomerService");
            wsHttpBindingClient.Endpoint.EndpointBehaviors.Add(new MyOperationBehavior());
            Customer[] wsHttpCustomers = basicHttpBindingClient.Get();

            // NetTcpBinding
            CustomerServiceClient netTcpBindingClient = new CustomerServiceClient("NetTcpBinding_ICustomerService");
            netTcpBindingClient.Endpoint.EndpointBehaviors.Add(new MyOperationBehavior());
            Customer[] netTcpCustomers = basicHttpBindingClient.Get();

            // NetNamedPipeBinding
            CustomerServiceClient netNamedPipeBindingClient = new CustomerServiceClient("NetNamedPipeBinding_ICustomerService");
            netNamedPipeBindingClient.Endpoint.EndpointBehaviors.Add(new MyOperationBehavior());
            Customer[] netNamedPipeCustomers = basicHttpBindingClient.Get();

            Console.WriteLine("Press <Enter> to stop the client.");
            Console.ReadLine();
        }
    }
}
