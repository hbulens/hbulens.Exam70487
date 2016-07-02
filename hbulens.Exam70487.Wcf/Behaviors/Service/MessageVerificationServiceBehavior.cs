using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Inspectors
{
    public class MessageVerificationServiceBehavior : BehaviorExtensionElement, IServiceBehavior
    {
        #region IServiceBehavior

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            Console.WriteLine("In MessageVerificationServiceBehavior.AddBindingParameters");
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            Console.WriteLine("In MessageVerificationServiceBehavior.ApplyDispatchBehavior");

        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            Console.WriteLine("In MessageVerificationServiceBehavior.Validate");
        }

        #endregion IServiceBehavior

        #region Configuration

        public override Type BehaviorType
        {
            get { return typeof(MessageVerificationEndPointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new MessageVerificationEndPointBehavior();
        }

        #endregion Configuration
    }
}
