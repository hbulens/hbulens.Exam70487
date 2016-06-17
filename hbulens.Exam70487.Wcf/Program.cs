using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf
{
    class Program
    {
        /// <summary>
        /// This project hosts the WCF Service. Tutorial how to set this up: https://msdn.microsoft.com/en-us/library/ms731758(v=vs.110).aspx
        ///  Might need to run the project or executable as an administrator.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool useAppConfig = Convert.ToBoolean(ConfigurationManager.AppSettings["UseAppConfig"]);            
            using (ServiceHost host = new ServiceHost(typeof(CustomerService)))
            {
                BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
                WSHttpBinding wsHttpBinding = new WSHttpBinding();
                Uri baseHttpAddress = new Uri("http://localhost:8080/Customers");
                host.AddServiceEndpoint(typeof(ICustomerService), basicHttpBinding, baseHttpAddress);
                host.AddServiceEndpoint(typeof(ICustomerService), wsHttpBinding, baseHttpAddress + "/ws");

                if (!useAppConfig)
                {                   
                    // Enable metadata publishing.
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    host.Description.Behaviors.Add(smb);
                }

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
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
