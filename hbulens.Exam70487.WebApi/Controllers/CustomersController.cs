using hbulens.Exam70487.Common;
using hbulens.Exam70487.Core;
using hbulens.Exam70487.Core.Repositories;
using hbulens.Exam70487.Repositories;
using hbulens.Exam70487.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Http;

namespace hbulens.Exam70487.WebApi.Controllers
{
    public class CustomersController : ApiController
    {
        #region Constructor

        /// <summary>
        /// Use Dependency Injection to get the repository instance
        /// </summary>
        /// <param name="customerRepository"></param>
        public CustomersController(IRepository<Customer> customerRepository, IRepository<Audit> auditRepository)
        {
            this.CustomerRepository = customerRepository;
            this.AuditRepository = auditRepository;
        }

        #endregion Constructor

        #region Properties

        private IRepository<Customer> CustomerRepository { get; set; }
        private IRepository<Audit> AuditRepository { get; set; }

        #endregion Properties

        #region Methods

        [HttpGet]
        [DebugActionWebApiFilter]
        public IEnumerable<Customer> Get()
        {
            IEnumerable<Customer> customers = default(IEnumerable<Customer>);

            // *************************************************************************************************************************
            // The ADO.NET way
            // *************************************************************************************************************************
            using (IReadRepository<Customer> customerRepository = new CustomerRepository(nameof(ExamCodeFirstContext)))
            {
                customers = customerRepository.Get();
            }

            // *************************************************************************************************************************
            // The Entity Framework way
            // *************************************************************************************************************************
            using (IRepository<Customer> customerRepository = new EfRepository<Customer>(new ExamCodeFirstContext()))
            {
                customers = customerRepository.Get();
            }

            // *************************************************************************************************************************
            // The Model First Way
            // *************************************************************************************************************************
            using (IRepository<Core.Model_First.Customer> customerRepository = new EfRepository<Core.Model_First.Customer>(new Core.Model_First.ExamModelFirstContext()))
            {
                IEnumerable<Core.Model_First.Customer> customersFromModelFirst = customerRepository.Get();
            }

            // *************************************************************************************************************************
            // The DI way
            // *************************************************************************************************************************
            customers = this.CustomerRepository.Get();

            // *************************************************************************************************************************
            // The good old way of the ObjectContext
            // *************************************************************************************************************************
            if (this.CustomerRepository is EfRepository<Customer>)
            {
                // Use explicit conversion to get the DbContext from the repository without exposing the DbContext property as public
                ExamCodeFirstContext ctx = (ExamCodeFirstContext)(EfRepository<Customer>)this.CustomerRepository;

                IQueryable<Customer> customersDeferred = ctx.Customers.Where(x => x.Id > 1);
                customersDeferred.Load();
                customersDeferred.Where(x => x.FirstName == "Donald");

                IQueryable<Customer> customersDeferred2 = ctx.Customers.Where(x => x.Id > 1);
                customersDeferred2.Where(x => x.FirstName == "Donald");

                // Use the adapter to get to the old ObjectContext type
                IObjectContextAdapter adapter = (IObjectContextAdapter)ctx;
                ObjectContext objectContext = adapter.ObjectContext;

                // Create same query as the others with the ObjectContext directly
                ObjectQuery<Customer> customersQuery = objectContext.CreateObjectSet<Customer>();

                // Get the trace string of the objcect query
                string query = customersQuery.ToTraceString();

                customers = customersQuery;
            }


            return customers.ToList();
        }

        [HttpPost]
        [DebugActionWebApiFilter]
        public Customer Post(Customer item)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Customer newCustomer = this.CustomerRepository.Create(item);
                this.AuditRepository.Create(new Audit() { Action = "Create", User = this.User?.Identity?.Name ?? "Anonymous" });
                scope.Complete();

                return newCustomer;
            }
        }

        [HttpPut]
        [DebugActionWebApiFilter]
        public Customer Put(Customer item)
        {
            return this.CustomerRepository.Update(item);
        }

        [HttpPatch]
        [DebugActionWebApiFilter]
        public Customer Patch(Customer item)
        {
            return this.CustomerRepository.Update(item);
        }

        [HttpDelete]
        [DebugActionWebApiFilter]
        public Customer Delete(Customer item)
        {
            return this.CustomerRepository.Delete(item);
        }

        protected override void Dispose(bool disposing)
        {
            this.CustomerRepository.Dispose();
            base.Dispose(disposing);
        }

        #endregion Methods
    }
}
