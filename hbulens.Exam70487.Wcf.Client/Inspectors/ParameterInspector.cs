using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Client.Inspectors
{
    public class ParameterInspector : IParameterInspector
    {
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Console.WriteLine("ParameterInspector.AfterCall called for {0} with return value {1}.", operationName, returnValue.ToString());
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            Console.WriteLine("ParameterInspector.BeforeCall called for {0}.", operationName);
            return null;
        }
    }
}
