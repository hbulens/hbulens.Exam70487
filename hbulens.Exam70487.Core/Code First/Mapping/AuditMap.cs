using hbulens.Exam70487.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hbulens.Exam70487
{
    internal class AuditMap : EntityTypeConfiguration<Audit>
    {
        internal AuditMap()
        {
            this.ToTable("Audits");
            this.HasKey(x => x.Id);            
        }
    }
}
