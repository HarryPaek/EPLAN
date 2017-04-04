using Eplan.ConfigurationTools;
using Eplan.Framework.Common.Interfaces.DataAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eplan.Framework.DataAccess.Oracle
{
    public class OracleDBAccessor : IDBAccessor
    {
        #region Constructor

        private OracleConnection _connection;

        /// <summary>
        /// Default constructor which uses the "OracleConnection" connectionString
        /// </summary>
        public OracleDBAccessor() : this("OracleConnection")
        {
        }

        /// <summary>
        /// Constructor which takes the connection string name
        /// </summary>
        /// <param name="connectionStringName"></param>
        public OracleDBAccessor(string connectionStringName)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            string connectionString = ConfiguratuionHelper.GetConfiguration(string.Empty).ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString;
            _connection = new OracleConnection(connectionString);
        }

        #endregion

        #region IDBAccessor Support

        public int ExecuteNonQuery(string commandText, Dictionary<string, object> parameters)
        {
            int result = 0;

            if (String.IsNullOrEmpty(commandText))
                throw new ArgumentException("Command text cannot be null or empty.");

            try {
                EnsureConnectionOpen();
                var command = CreateCommand(commandText, parameters);
                result = command.ExecuteNonQuery();
            }
            finally {
                _connection.Close();
            }

            return result;
        }

        public List<Dictionary<string, string>> ExecuteReader(string commandText, Dictionary<string, object> parameters)
        {
            List<Dictionary<string, string>> rows = null;

            if (String.IsNullOrEmpty(commandText))
                throw new ArgumentException("Command text cannot be null or empty.");

            try
            {
                EnsureConnectionOpen();
                var command = CreateCommand(commandText, parameters);
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    rows = new List<Dictionary<string, string>>();
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, string>();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var columnName = reader.GetName(i);
                            var columnValue = reader.IsDBNull(i) ? null : reader.GetString(i);
                            row.Add(columnName, columnValue);
                        }
                        rows.Add(row);
                    }
                }
            }
            finally
            {
                EnsureConnectionClosed();
            }

            return rows;
        }

        public object ExecuteScalar(string commandText, Dictionary<string, object> parameters)
        {
            object result = null;

            if (String.IsNullOrEmpty(commandText))
                throw new ArgumentException("Command text cannot be null or empty.");

            try
            {
                EnsureConnectionOpen();
                var command = CreateCommand(commandText, parameters);
                result = command.ExecuteScalar();
            }
            finally
            {
                EnsureConnectionClosed();
            }

            return result;
        }

        public string GetStrValue(string commandText, Dictionary<string, object> parameters)
        {
            string value = ExecuteScalar(commandText, parameters) as string;

            return value;
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Opens a connection if not open
        /// </summary>
        private void EnsureConnectionOpen()
        {
            var retries = 3;

            if (_connection.State == ConnectionState.Open)
                return;
            else
                while (retries >= 0 && _connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                    retries--;
                    Thread.Sleep(30);
                }
        }

        /// <summary>
        /// Closes a connection if open
        /// </summary>
        private void EnsureConnectionClosed()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        /// <summary>
        /// Creates a OracleCommand with the given parameters
        /// </summary>
        /// <param name="commandText">The Oracle query to execute</param>
        /// <param name="parameters">Parameters to pass to the Oracle query</param>
        /// <returns></returns>
        private OracleCommand CreateCommand(string commandText, Dictionary<string, object> parameters)
        {
            OracleCommand command = _connection.CreateCommand();
            command.CommandText = commandText;
            AddParameters(command, parameters);

            return command;
        }
    
        /// <summary>
        /// Adds the parameters to a Oracle command
        /// </summary>
        /// <param name="commandText">The Oracle query to execute</param>
        /// <param name="parameters">Parameters to pass to the Oracle query</param>
        private void AddParameters(OracleCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null)
                return;

            foreach (var param in parameters)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = param.Key;
                parameter.Value = param.Value ?? DBNull.Value;
                command.Parameters.Add(parameter);
            }
        }
  
        #endregion
    }
}
