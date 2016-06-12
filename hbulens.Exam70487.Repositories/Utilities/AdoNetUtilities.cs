using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Repositories
{
    internal static class AdoNetUtilities
    {
        internal static Dictionary<string, int> GetAllNames(this IDataRecord record)
        {
            var result = new Dictionary<string, int>();
            for (int i = 0; i < record.FieldCount; i++)
            {
                result.Add(record.GetName(i), i);
            }
            return result;
        }

        /// <summary>
        /// Simple method for converting an expression into a valid SQL where clause
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        internal static string ToString<T>(this Expression<Func<T, bool>> filter)
        {
            string expBody = ((LambdaExpression)filter).Body.ToString();

            var paramName = filter.Parameters[0].Name;
            var paramTypeName = filter.Parameters[0].Type.Name;

            expBody = expBody.Replace(paramName + ".", "").Replace("AndAlso", "&&").Replace("==", "=").Replace("\"", "'");

            return expBody;
        }
    }
}
