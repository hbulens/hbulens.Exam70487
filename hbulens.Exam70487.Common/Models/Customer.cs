using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Common
{
    public class Customer : Item
    {
        #region Constructor

        public Customer()
        {

        }

        public Customer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        #endregion Constructor

        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
      
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        #endregion Properties

        #region Methods

        public static bool TryParse(string s, out Customer result)
        {
            result = null;

            var parts = s.Split(',');
            if (parts.Length != 3)
            {
                return false;
            }

            int id = 0;

            if (int.TryParse(parts[0], out id) && parts[1] != null && parts[2] != null)
            {
                result = new Customer() { Id = id, FirstName = parts[1], LastName = parts[2] };
                return true;
            }
            return false;
        }

        #endregion Methods
    }
}
