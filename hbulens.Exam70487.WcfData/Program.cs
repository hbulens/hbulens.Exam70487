using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace hbulens.Exam70487.WcfData
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8083/ExamDataService");
            Uri[] baseAddresses = new Uri[] { baseAddress };

            using (DataServiceHost host = new DataServiceHost(typeof(ExamDataService), baseAddresses))
            {
                ServiceEndpoint endPoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(ExamDataService)))
                {
                    Name = "default",
                    Address = new EndpointAddress(baseAddress),
                    Contract = ContractDescription.GetContract(typeof(IRequestHandler)),
                    Binding = new WebHttpBinding()
                };

                // Add extra behavior to enable CORS
                endPoint.EndpointBehaviors.Add(new EnableCrossOriginResourceSharingBehavior());

                host.AddServiceEndpoint(endPoint);            
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the DataServiceHost.
                host.Close();
            }
        }
    }
}
