using hbulens.Exam70487.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hbulens.Exam70487
{
    internal class CustomerMap : EntityTypeConfiguration<Customer>
    {
        internal CustomerMap()
        {
            this.ToTable("Customers");
            this.HasKey(x => x.Id);

        }
    }
}
