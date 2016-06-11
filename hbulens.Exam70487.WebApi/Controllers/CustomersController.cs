using hbulens.Exam70487.Common;
using hbulens.Exam70487.Core;
using hbulens.Exam70487.Repositories;
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

        public CustomersController()
        {

        }

        #endregion Constructor

        #region Properties

        #endregion Properties

        #region Methods

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            using (IRepository<Customer> customerRepository = new EFRepository<Customer>(new ExamContext()))
            {
                return customerRepository.Get();
            }
        }

        #endregion Methods
    }
}
