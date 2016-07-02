using hbulens.Exam70487.Wcf.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Inspectors
{
    public class MessageVerificationEndPointBehavior : IEndpointBehavior
    {
        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            MessageInspector inspector = new MessageInspector();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new MyErrorHandler());

        }
    }
}
