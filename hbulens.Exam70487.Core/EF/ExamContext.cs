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
    public class ExamContext : DbContext
    {
        #region Constructor

        public ExamContext()
        {
        }

        #endregion Constructor

        #region Properties

        public DbSet<Customer> Customers { get; set; }

        #endregion Properties

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Customer>(new CustomerMap());
        }

        #endregion Methods                
    }
}
