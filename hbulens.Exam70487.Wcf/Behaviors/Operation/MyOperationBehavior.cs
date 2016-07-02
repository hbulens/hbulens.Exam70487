using hbulens.Exam70487.Wcf.Formatters;
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
    public class MyOperationBehavior : Attribute, IOperationBehavior
    {
        public void Validate(OperationDescription operationDescription)
        {
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(new ParameterInspector());            
        }
    }
}
