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
using System.Web.Http.ModelBinding;

namespace hbulens.Exam70487.WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        #region Constructor

        public OrdersController(IRepository<Order> orderRepository)
        {
            this.OrderRepository = orderRepository;
        }

        #endregion Constructor

        #region Properties

        private IRepository<Order> OrderRepository { get; set; }

        #endregion Properties

        #region Methods

        [HttpGet]
        [DebugActionWebApiFilter]
        public IEnumerable<Order> Get([FromUri]Customer customer)
        {
            return this.OrderRepository.Get(x => x.CustomerId == customer.Id);
        }

        [HttpGet]
        [DebugActionWebApiFilter]
        public Order GetLatest([ModelBinder(typeof(CustomerModelBinder))]Customer customer)
        {
            if (customer == null)
            {
                throw new Exception("");
            }
            else
            {
                IEnumerable<Order> orders = this.OrderRepository.Get(x => x.CustomerId == customer.Id);
                return orders.LastOrDefault();
            }
        }

        #endregion Methods
    }
}
