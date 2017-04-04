using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.Framework.Common.Interfaces.DataAccess
{
    public interface IDBAccessor : IDisposable
    {
        int ExecuteNonQuery(string commandText, Dictionary<string, object> parameters = null);

        object ExecuteScalar(string commandText, Dictionary<string, object> parameters = null);
        string GetStrValue(string commandText, Dictionary<string, object> parameters = null);

        List<Dictionary<string, string>> ExecuteReader(string commandText, Dictionary<string, object> parameters = null);
    }
}
