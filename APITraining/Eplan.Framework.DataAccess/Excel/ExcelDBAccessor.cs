using Eplan.ConfigurationTools;
using Eplan.Framework.Common.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Threading;

namespace Eplan.Framework.DataAccess.Excel
{
    public class ExcelDBAccessor : IDBAccessor
    {
        #region Constructor

        private OleDbConnection _connection;
        private string _connectionName;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ExcelDBAccessor() : this("ExcelConnection")
        {
        }

        /// <summary>
        /// Constructor which takes "ExcelConnection"
        /// </summary>
        /// <param name="connectionName"></param>
        public ExcelDBAccessor(string connectionName)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
                throw new ArgumentNullException("connectionName");

            Configuration configuration = ConfiguratuionHelper.GetConfiguration(string.Empty);
            string connectionString = configuration.ConnectionStrings.ConnectionStrings[connectionName].ConnectionString;

            this._connection = new OleDbConnection(connectionString);
            this._connectionName = connectionName;
        }

        #endregion

        #region IDBAccessor Support

        public string DataSource
        {
            get { return this._connection.DataSource; }
        }

        public int ExecuteNonQuery(string commandText, Dictionary<string, object> parameters)
        {
            int result = 0;

            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Command text cannot be null or empty.", "commandText");

            try
            {
                EnsureConnectionOpen();
                using (OleDbCommand command = CreateCommand(commandText, parameters))
                {
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                EnsureConnectionClosed();
            }

            return result;
        }

        public List<Dictionary<string, string>> ExecuteReader(string commandText, Dictionary<string, object> parameters)
        {
            List<Dictionary<string, string>> rows = null;

            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Command text cannot be null or empty.", "commandText");

            try
            {
                EnsureConnectionOpen();

                DataTable dtExcelSchema = _connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                using (OleDbCommand command = CreateCommand(commandText, parameters))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        rows = new List<Dictionary<string, string>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                var columnName = reader.GetName(i);
                                var columnValue = reader.IsDBNull(i) ? string.Empty : reader.GetValue(i).ToString();
                                row.Add(columnName, columnValue);
                            }

                            rows.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Command text cannot be null or empty.", "commandText");

            try
            {
                EnsureConnectionOpen();
                using (OleDbCommand command = CreateCommand(commandText, parameters))
                {
                    result = command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                EnsureConnectionClosed();
            }

            return result;
        }

        public string GetStrValue(string commandText, Dictionary<string, object> parameters)
        {
            object value = ExecuteScalar(commandText, parameters);

            return value == null ? null : value.ToString();
        }

        public DataTable ExecuteSelect(string commandText, Dictionary<string, object> parameters)
        {
            DataTable rows = new DataTable();
            OleDbDataAdapter dataAdapter = null;

            if (string.IsNullOrWhiteSpace(commandText))
                throw new ArgumentException("Command text cannot be null or empty.", "commandText");

            try
            {
                EnsureConnectionOpen();
                using (OleDbCommand command = CreateCommand(commandText, parameters))
                {
                    dataAdapter = new OleDbDataAdapter(command);
                    dataAdapter.Fill(rows);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dataAdapter != null)
                    dataAdapter.Dispose();

                EnsureConnectionClosed();
            }

            return rows;
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    if (_connection != null) {
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
        private OleDbCommand CreateCommand(string commandText, Dictionary<string, object> parameters)
        {
            OleDbCommand command = _connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();

            command.CommandText = commandText;
            AddParameters(command, parameters);

            return command;
        }

        /// <summary>
        /// Adds the parameters to a Oracle command
        /// </summary>
        /// <param name="commandText">The Oracle query to execute</param>
        /// <param name="parameters">Parameters to pass to the Oracle query</param>
        private void AddParameters(OleDbCommand command, Dictionary<string, object> parameters)
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
