using hbulens.Exam70487.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ExamCodeFirstContext : DbContext
    {
        #region Constructor

        public ExamCodeFirstContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        #endregion Constructor

        #region Properties

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Audit> Audits { get; set; }

        #endregion Properties

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new AuditMap());
        }

        #endregion Methods                
    }
}
