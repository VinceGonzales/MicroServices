using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Interchange.Data
{
    /// <summary>
    /// Oracle Stored procedure Facade class
    /// </summary>
    public class StoredProcFacade : AbstractFacade, IDisposable
    {
        #region Public Methods

        public StoredProcFacade() { }

        public override void SetStoredProc(string commandName)
        {
            Connection = new OracleConnection(this.ConnectionString);
            CMD = new OracleCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = commandName,
                Connection = _conn
            };
        }

        public override void OpenConnection()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());

            Connection.Open();
        }

        public override void CloseConnection()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            if (_conn == null)
                throw new Exception("Connection is not assigned");
            Connection.Close();
        }

        #endregion

        #region Oracle command helpers

        public override void AddParamInDate(string paramName, DateTime paramValue)
        {
            if (paramValue == null)
                paramValue = DateTime.Today;
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, paramValue)
            {
                OracleDbType = OracleDbType.Date,
                Size = 32767,//paramValue.Length,
                Direction = ParameterDirection.Input,
                Value = paramValue
            };
            _cmd.Parameters.Add(param);
        }

        public override void AddParamInDateNullable(string paramName, DateTime? paramValue)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, paramValue)
            {
                OracleDbType = OracleDbType.Date,
                Size = 32767,
                Direction = ParameterDirection.Input,
                Value = OracleDate.Null
            };
            _cmd.Parameters.Add(param);
        }

        public override void AddParamInString(string paramName, string paramValue)
        {
            if (paramValue == null)
                paramValue = string.Empty;
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, paramValue)
            {
                OracleDbType = OracleDbType.Varchar2,
                Size = 32767,//paramValue.Length,
                Direction = ParameterDirection.Input,
                Value = paramValue
            };
            _cmd.Parameters.Add(param);
        }

        public override void AddParamInInt32(string paramName, Int32 paramValue)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, paramValue)
            {
                OracleDbType = OracleDbType.Int32,
                Size = 0,
                Direction = ParameterDirection.Input,
                Value = paramValue
            };
            _cmd.Parameters.Add(param);
        }

        public override void AddParamInIntNullable(string paramName, int? paramValue)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, paramValue)
            {
                OracleDbType = OracleDbType.Int32,
                Size = 0,
                Direction = ParameterDirection.Input,
                Value = paramValue
            };
            _cmd.Parameters.Add(param);
        }

        public override void AddParamInInt64(string paramName, Int64 paramValue)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, paramValue)
            {
                OracleDbType = OracleDbType.Int64,
                Size = 0,
                Direction = ParameterDirection.Input,
                Value = paramValue
            };
            _cmd.Parameters.Add(param);
        }

        public override void AddParamInDecimal(string paramName, decimal paramValue)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, paramValue)
            {
                OracleDbType = OracleDbType.Decimal,
                Size = 0,
                Direction = ParameterDirection.Input,
                Value = paramValue
            };
            _cmd.Parameters.Add(param);
        }

        public void AddParamInRefCursor(string paramName, OracleRefCursor paramValue)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, OracleDbType.RefCursor, 2000, "")
            {
                OracleDbType = OracleDbType.RefCursor,
                Size = 0,
                Direction = ParameterDirection.Input,
                Value = paramValue

            };
            _cmd.Parameters.Add(param);
        }

        public override void AddParamOutInt32(string paramName, int size)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, OracleDbType.Int32, size)
            {
                Direction = ParameterDirection.Output
            };
            _cmd.Parameters.Add(param);
        }

        public override int GetParamOutInt32(string paramName)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            OracleParameter param = _cmd.Parameters[paramName];
            if ((param.Value != DBNull.Value))
            {
                var val = (param.Value);
                return Convert.ToInt32(val.ToString());
            }
            return 0;
        }

        public override void AddParamOutDecimal(string paramName)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, OracleDbType.Decimal)
            {
                Direction = ParameterDirection.Output
            };
            _cmd.Parameters.Add(param);
        }

        public override void AddParamOutString(string paramName, int size)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, OracleDbType.NVarchar2)
            {
                OracleDbType = OracleDbType.Varchar2,
                Size = size,
                Direction = ParameterDirection.Output
            };
            _cmd.Parameters.Add(param);
        }

        public override string GetParamOutString(string paramName)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = _cmd.Parameters[paramName];
            param.Size = 32767;
            return Convert.ToString(param.Value);
        }

        public override void AddParamOutRefCursor(string paramName, int size)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, OracleDbType.RefCursor, 2000, "")
            {
                Direction = ParameterDirection.Output,
                Size = size,
            };
            _cmd.Parameters.Add(param);
        }

        public override void AddParamOutDate(string paramName)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var param = new OracleParameter(paramName, OracleDbType.Date)
            {
                Size = 32767,
                Direction = ParameterDirection.Output
            };
            _cmd.Parameters.Add(param);
        }
        #endregion

        #region Execute

        public override void Execute()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            _cmd.ExecuteNonQuery();
        }

        public override DataSet FillDataSet()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            DataSet ds = new DataSet();
            adapter = new OracleDataAdapter(_cmd);
            adapter.Fill(ds);
            return ds;
        }

        #endregion

        #region Oracle error formatting helpers

        public override string ParamsValue()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().ToString());
            var sb = new StringBuilder();
            foreach (OracleParameter p in _cmd.Parameters)
            {
                sb.Append("Name :");
                sb.Append(p.ParameterName);
                sb.Append("\n");
                sb.Append("Type : ");
                sb.Append(p.OracleDbType.ToString());
                sb.Append("\n");
                if (p.OracleDbType != OracleDbType.RefCursor)
                {
                    sb.Append("Value: ");
                    sb.Append(p.Value == null ? "<null>" : p.Value.ToString());
                    sb.Append("\n");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        #endregion

        #region IDisposable Members

        private bool _isDisposed;

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_cmd != null)
                    _cmd.Dispose();
                if (_conn != null)
                    CloseConnection();
                _isDisposed = disposing;
            }
        }
        #endregion

        ~StoredProcFacade()
        {
            Dispose(false);
        }

        #region Class variables

        private OracleConnection _conn;
        private OracleCommand _cmd;
        private OracleDataAdapter adapter;

        public override DbConnection Connection
        {
            get
            {
                return _conn;
            }
            set
            {
                _conn = value as OracleConnection;
            }
        }
        public override DbCommand CMD
        {
            get
            {
                return _cmd;
            }
            set
            {
                _cmd = value as OracleCommand;
            }
        }
        /*
        public override DbDataAdapter Adapter
        {
            get
            {
                if (adapter == null)
                {
                    adapter = new OracleDataAdapter(_cmd);
                }
                return adapter;
            }
            set
            {
                adapter = value as OracleDataAdapter;
            }
        }*/
        #endregion

    }
}
