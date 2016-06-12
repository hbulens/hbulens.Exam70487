using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Repositories
{
    public abstract class AdoRepository<T> : IRepository<T>
    {
        #region Constructor

        public AdoRepository(string connection)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
            this.Connection = new SqlConnection(connectionString);
        }

        public AdoRepository(string connection, string table) : this(connection)
        {
            this.Table = table;
        }

        #endregion Constructor

        #region Properties

        private SqlConnection Connection { get; set; }
        protected virtual string Table { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Get()
        {
            this.Connection.Open();

            using (SqlCommand command = this.Connection.CreateCommand())
            {
                command.CommandText = string.Format("SELECT * FROM {0}", this.Table);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return this.Map(reader);
                    }
                }
            }

            this.Connection.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            this.Connection.Open();

            using (SqlCommand command = this.Connection.CreateCommand())
            {
                command.CommandText = string.Format("SELECT * FROM {0} WHERE {1}", this.Table, filter.ToString<T>());
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return this.Map(reader);
                    }
                }
            }

            this.Connection.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Connection.Dispose();
        }

        protected T Map(IDataRecord record)
        {
            T item = Activator.CreateInstance<T>();
            IDictionary<string, int> fields = record.GetAllNames();

            foreach (var property in typeof(T).GetProperties())
            {
                if (fields.Select(x => x.Key).Contains(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                {
                    property.SetValue(item, record[property.Name]);
                }
            }
            return item;
        }

        #endregion Methods

    }
}
