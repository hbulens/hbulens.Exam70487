using hbulens.Exam70487.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hbulens.Exam70487
{
    internal class OrderMap : EntityTypeConfiguration<Order>
    {
        internal OrderMap()
        {
            this.ToTable("Orders");
            this.HasKey(x => x.Id);
            this.HasRequired(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);

        }
    }
}
