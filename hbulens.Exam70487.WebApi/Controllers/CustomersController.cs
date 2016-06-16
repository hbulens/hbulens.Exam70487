using hbulens.Exam70487.Common;
using hbulens.Exam70487.Core;
using hbulens.Exam70487.Core.Repositories;
using hbulens.Exam70487.Repositories;
using hbulens.Exam70487.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace hbulens.Exam70487.WebApi.Controllers
{
    public class CustomersController : ApiController
    {
        #region Constructor

        public CustomersController(IRepository<Customer> customerRepository)
        {
            this.CustomerRepository = customerRepository;
        }

        #endregion Constructor

        #region Properties

        private IRepository<Customer> CustomerRepository { get; set; }

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
            using (IRepository<Customer> customerRepository = new CustomerRepository("ExamContext"))
            {
                customers = customerRepository.Get();
            }

            // *************************************************************************************************************************
            // The Entity Framework way
            // *************************************************************************************************************************
            using (IRepository<Customer> customerRepository = new EfRepository<Customer>(new ExamContext()))
            {
                customers = customerRepository.Get();
            }

            // *************************************************************************************************************************
            // The DI way
            // *************************************************************************************************************************
            customers = this.CustomerRepository.Get();

            return customers.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            this.CustomerRepository.Dispose();
            base.Dispose(disposing);
        }
        #endregion Methods
    }


}
