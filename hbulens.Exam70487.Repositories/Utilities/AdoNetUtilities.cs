using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    }
}
