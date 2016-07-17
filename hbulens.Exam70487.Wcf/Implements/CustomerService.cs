using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hbulens.Exam70487.Common;
using System.ServiceModel;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;

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
            Random random = new Random();
            if (random.Next(1, 5) == 3)
            {
                InvalidOperationException ioEx = new InvalidOperationException("You hit the jackpot!");
                throw new FaultException<InvalidOperationException>(
                    ioEx,
                    new FaultReason("FaultReason Bla Bla"),
                    new FaultCode("VersionMismatch"));
            }
            else
            {
                return new List<Customer>() { new Customer("Donald", "Trump") { } };
            }
        }

        [OperationBehavior(TransactionScopeRequired = false, TransactionAutoComplete = true)]
        public bool Add(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamCodeFirstContext"].ConnectionString))
            {
                // Right command
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Customers (FirstName, Lastname) VALUES ('" + customer.FirstName + "', '" + customer.LastName + "')", connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return true;
        }

        public void SaveChanges()
        {
            Thread.Sleep(5000);
        }

        #endregion Methods        
    }
}
