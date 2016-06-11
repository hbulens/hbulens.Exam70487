using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        #region Constructor

        public EFRepository(DbContext ctx)
        {
            this.Context = ctx;
        }

        #endregion Constructor

        #region Properties

        private DbContext Context { get; set; }

        #endregion Properties

        #region Methods

        public IEnumerable<T> Get()
        {
            return this.Context.Set<T>().ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return this.Context.Set<T>().Where(filter).ToList();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        #endregion Methods


    }
}
