using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Common
{
    public class Customer : Entity
    {
        #region Constructor

        public Customer()
        {

        }

        public Customer(string name)
        {
            this.Name = name;
        }

        #endregion Constructor
    }
}
