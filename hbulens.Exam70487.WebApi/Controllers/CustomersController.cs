using hbulens.Exam70487.Common;
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
            return new List<Customer>()
            {
                new Customer("Donald", "Trump") {},
                new Customer("Hillary", "Clinton") {},
                new Customer("Barack", "Obama") {},
                new Customer("Deez", "Nuts") {},
                new Customer("Bernie", "Sanders") {},
                new Customer("George", "Bush") {},
                new Customer("Bill", "Clinton") {},
                new Customer("Franklin", "Roosevelt") {},
                new Customer("Benjamin", "Franklin") {}
            };
        }

        #endregion Methods
    }
}
