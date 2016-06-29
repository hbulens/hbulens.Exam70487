using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace hbulens.Exam70487.Wcf.Duplex
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class DuplexService : IDuplexService
    {
        public static IDuplexServiceCallBack Callback;
        public static Timer Timer;

        public void OpenSession()
        {
            Console.WriteLine("> Session opened at {0}", DateTime.Now);
            Callback = OperationContext.Current.GetCallbackChannel<IDuplexServiceCallBack>();

            Timer = new Timer(1000);
            Timer.Elapsed += OnTimerElapsed;
            Timer.Enabled = true;
        }

        void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Callback.OnCallback();
        }
    }
}
