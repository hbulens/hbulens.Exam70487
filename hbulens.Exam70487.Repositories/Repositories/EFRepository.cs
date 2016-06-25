using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        #region Constructor

        public EfRepository(DbContext ctx)
        {
            this.Context = ctx;
        }

        public EfRepository(DbContext ctx, bool saveInBatch) : this(ctx)
        {
            this.Batch = saveInBatch;
        }


        #endregion Constructor

        #region Properties

        private DbContext Context { get; set; }
        private bool Batch { get; set; }

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

        public T Update(T item)
        {
            T record = this.Context.Set<T>().Attach(item);
            this.Context.Entry(record).State = EntityState.Modified;

            if (!this.Batch)
                this.SaveChanges();

            return record;
        }

        public T Create(T item)
        {
            T record = this.Context.Set<T>().Add(item);

            if (!this.Batch)
                this.SaveChanges();

            return record;
        }

        public T Delete(T item)
        {
            T record = this.Context.Set<T>().Remove(item);

            if (!this.Batch)
                this.SaveChanges();

            return record;
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
        
        public static explicit operator DbContext(EfRepository<T> repository)
        {
            return repository.Context;
        }

        #endregion Methods
    }
}
