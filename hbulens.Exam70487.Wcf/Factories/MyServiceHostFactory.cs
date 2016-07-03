using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Factories
{
    public class MyServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost host = new ServiceHost(serviceType, baseAddresses);
            host.AddServiceEndpoint(typeof(ICustomerService), new WSHttpBinding(), baseAddresses.ElementAt(0) + "/ws");

            return host;
        }
    }
}
