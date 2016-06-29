using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Duplex
{
    [ServiceContract(CallbackContract = typeof(IDuplexServiceCallBack))]
    public interface IDuplexService
    {
        [OperationContract]
        void OpenSession();
    }
}
