using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Duplex
{
    public interface IDuplexServiceCallBack
    {
        [OperationContract]
        void OnCallback();
    }
}
