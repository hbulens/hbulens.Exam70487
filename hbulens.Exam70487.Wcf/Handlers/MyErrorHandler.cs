using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Handlers
{
    public class MyErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            Console.WriteLine(string.Format("Crikey! Error occurred: {0}", error.Message));
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
            {
                // Let WCF do normal processing
            }
            else
            {               
                MessageFault messageFault = MessageFault.CreateFault(new FaultCode("Sender"),new FaultReason(error.Message),error,new NetDataContractSerializer());
                fault = Message.CreateMessage(version, messageFault, null);
            }
        }
    }
}
