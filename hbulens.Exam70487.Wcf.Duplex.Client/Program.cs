using hbulens.Exam70487.Wcf.Duplex.Client.DuplexService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Duplex.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to continue once service is hosted.");
            Console.ReadLine();

            DuplexServiceCallBack callback = new DuplexServiceCallBack();
            InstanceContext instanceContext = new InstanceContext(callback);
            DuplexServiceClient client = new DuplexServiceClient(instanceContext);

            client.OpenSession();

            Console.WriteLine("Press <ESC> to stop the client.");
            Console.ReadLine();
        }
    }
}
