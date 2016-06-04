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

        #region Methods

        public static bool TryParse(string s, out Customer result)
        {
            result = null;

            var parts = s.Split(',');
            if (parts.Length != 2)
            {
                return false;
            }

            int id = 0;
            string name = "";

            if (int.TryParse(parts[0], out id) && parts[1] != null)
            {
                result = new Customer() { Id = id, Name = name };
                return true;
            }
            return false;
        }

        #endregion Methods
    }
}
