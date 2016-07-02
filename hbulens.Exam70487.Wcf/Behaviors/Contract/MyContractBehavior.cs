using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Behaviors.Contract
{
    public class MyContractBehaviorAttribute : Attribute, IContractBehavior
    {
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            Console.WriteLine("In MyContractBehaviorAttribute.AddBindingParameters");
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            Console.WriteLine("In MyContractBehaviorAttribute.ApplyClientBehavior");
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            Console.WriteLine("In MyContractBehaviorAttribute.ApplyDispatchBehavior"); throw new NotImplementedException();
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            Console.WriteLine("In MyContractBehaviorAttribute.Validate");
        }
    }
}
