using System;
using System.Collections.Generic;
using System.Data.Services.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Common
{
    [DataServiceKey("Id")]
    public class Order : Item
    {
        #region Constructor

        public Order()
        {
        }

        #endregion Constructor

        #region Properties

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        #endregion Properties

        #region Methods

        #endregion Methods
    }
}
