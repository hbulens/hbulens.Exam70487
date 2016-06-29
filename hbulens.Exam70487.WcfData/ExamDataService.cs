using hbulens.Exam70487.Common;
using hbulens.Exam70487.Core;
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.WcfData
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ExamDataService : EntityFrameworkDataService<ExamCodeFirstContext>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.UseVerboseErrors = true;
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }


        [ChangeInterceptor("Customers")]
        public void OnChangeCustomer(Customer customer, UpdateOperations operations)
        {
            Console.WriteLine("OnChangeCustomer ChangeInterceptor called");
        }

        [QueryInterceptor("Customers")]
        public Expression<Func<Customer, bool>> OnQueryCustomers()
        {
            Console.WriteLine("OnQueryCustomers QueryInterceptor called");
            return (x) => x.Id > 0;
        }
    }
}
