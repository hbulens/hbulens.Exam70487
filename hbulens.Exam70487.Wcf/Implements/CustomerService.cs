using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hbulens.Exam70487.Common;
using System.ServiceModel;
using System.Threading;

namespace hbulens.Exam70487.Wcf
{
    [ServiceBehavior]
    public class CustomerService : ICustomerService
    {
        #region Constructor

        public CustomerService()
        {

        }

        #endregion Constructor

        #region Properties

        #endregion Properties

        #region Methods
      
        public IEnumerable<Customer> Get()
        {
            return new List<Customer>() { new Customer("Donald", "Trump") { } };
        }

        public void SaveChanges()
        {
            Thread.Sleep(5000);
        }

        #endregion Methods        
    }
}
