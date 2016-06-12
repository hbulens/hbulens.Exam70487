using hbulens.Exam70487.Common;
using hbulens.Exam70487.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Core.Repositories
{
    public class CustomerRepository : AdoRepository<Customer>
    {
        public CustomerRepository(string connection) : base(connection, "Customers")
        {
        }
    }
}
