using System;
using System.Collections.Generic;
using System.Data.Services.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Common
{
    [DataServiceKey("Id")]
    [DataContract]
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

        [DataMember(Order = 1)]
        public string FirstName { get; set; }

        [DataMember(Order = 2)]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

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
            int id = 0;

            string[] parts = s.Split(',');

            if (parts.Length == 1)
            {
                int.TryParse(parts[0], out id);
                result = new Customer() { Id = id };
                return true;
            }
            else if (parts.Length != 3)
            {
                return false;
            }

            if (int.TryParse(parts[0], out id) && parts[1] != null && parts[2] != null)
            {
                result = new Customer() { Id = id, FirstName = parts[1], LastName = parts[2] };
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + this.FirstName.GetHashCode();
            hash = (hash * 7) + this.LastName.GetHashCode();

            return hash;
        }

        #endregion Methods
    }
}
