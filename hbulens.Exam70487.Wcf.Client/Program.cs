using hbulens.Exam70487.Wcf.Client.CustomerService;
using hbulens.Exam70487.Wcf.Client.Inspectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace hbulens.Exam70487.Wcf.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // WSHttpBinding
            CustomerServiceClient wsHttpBindingClient = new CustomerServiceClient("WSHttpBinding_ICustomerService");            
            wsHttpBindingClient.Endpoint.EndpointBehaviors.Add(new MyOperationBehavior());
            Common.Customer[] wsHttpCustomers = wsHttpBindingClient.Get();
            wsHttpBindingClient.SaveChanges();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    wsHttpBindingClient.Add(new Common.Customer() { FirstName = "Bill", LastName = "Jobs" });
                    wsHttpBindingClient.Add(null);
                    scope.Complete();
                }
            }
            catch (FaultException ex)
            {
                Console.WriteLine("Whoops! " + ex.Message);
            }

            // In order to use the ChannelFactory, add reference to the WCF Service Library + the library that contains the models
            WSHttpBinding myBinding = new WSHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress("http://localhost:8080/Customers/ws");
            ChannelFactory<ICustomerService> myChannelFactory = new ChannelFactory<ICustomerService>(myBinding, myEndpoint);
            ICustomerService customerService = myChannelFactory.CreateChannel();
            IEnumerable<Common.Customer> channelFactoryCustomers = customerService.Get();

            // NetTcpBinding
            CustomerServiceClient netTcpBindingClient = new CustomerServiceClient("NetTcpBinding_ICustomerService");
            netTcpBindingClient.Endpoint.EndpointBehaviors.Add(new MyOperationBehavior());
            Common.Customer[] netTcpCustomers = netTcpBindingClient.Get();
            
            // NetNamedPipeBinding
            CustomerServiceClient netNamedPipeBindingClient = new CustomerServiceClient("NetNamedPipeBinding_ICustomerService");
            netNamedPipeBindingClient.Endpoint.EndpointBehaviors.Add(new MyOperationBehavior());
            Common.Customer[] netNamedPipeCustomers = netNamedPipeBindingClient.Get();

            Console.WriteLine("Press <Enter> to stop the client.");
            Console.ReadLine();
        }
    }
}
