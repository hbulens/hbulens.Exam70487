using hbulens.Exam70487.Wcf.Duplex;
using hbulens.Exam70487.Wcf.Duplex.Client.DuplexService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Duplex.Client
{
    public class DuplexServiceCallBack : IDuplexServiceCallback
    {
        public void OnCallback()
        {
            Console.WriteLine("> Received callback at {0}", DateTime.Now);
        }
    }
}
