using hbulens.Exam70487.Common;
using hbulens.Exam70487.Wcf.Inspectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf
{
    [ServiceContract]
    public interface ICustomerService
    {
        [MyOperationBehavior]
        [OperationContract]
        IEnumerable<Customer> Get();
    }
}
