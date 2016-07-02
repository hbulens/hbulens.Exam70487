using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace hbulens.Exam70487.Wcf
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomHeaderMessageInspector : IDispatchMessageInspector
    {
        #region Constructor

        public CustomHeaderMessageInspector(Dictionary<string, string> headers)
        {
            requiredHeaders = headers ?? new Dictionary<string, string>();
        }

        #endregion PropertiesConstructor

        #region Properties

        Dictionary<string, string> requiredHeaders;

        #endregion Properties

        #region Methods

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            Console.WriteLine("Message:");
            Console.WriteLine(request);
            Console.WriteLine();
                                        
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var httpHeader = reply.Properties["httpResponse"] as HttpResponseMessageProperty;
            foreach (var item in requiredHeaders)
            {
                httpHeader.Headers.Add(item.Key, item.Value);
            }
        }

        #endregion Properties
    }
}
