using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Client.Inspectors
{
    public class MessageVerificationServiceBehavior : BehaviorExtensionElement, IServiceBehavior
    {
        #region IServiceBehavior Members

        public void AddBindingParameters(ServiceDescription serviceDescription,
            System.ServiceModel.ServiceHostBase serviceHostBase,
            System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
            System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {

        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {

        }

        #endregion

        public override Type BehaviorType
        {
            get { return typeof(MessageVerificationBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new MessageVerificationBehavior();
        }
    }
}
