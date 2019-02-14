using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interchange.Data
{
    public abstract class AbstractFacade
    {
        private string _connString;
        private SqlConnection _connection = null;
        private SqlCommand _command = null;
        private SqlDataAdapter adapter = null;

        public virtual DbConnection Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value as SqlConnection;
            }
        }
        public virtual DbCommand CMD
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value as SqlCommand;
            }
        }
        public virtual string ConnectionString
        {
            get
            {
                return _connString;
            }
            set
            {
                _connString = value;
            }
        }

        public virtual void SetStoredProc(string commandName)
        {
            Connection = new SqlConnection(this.ConnectionString);
            _command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = commandName,
                Connection = _connection
            };
        }

        public virtual void OpenConnection()
        {
            _connection.Open();
        }

        public virtual void CloseConnection()
        {
            _connection.Close();
        }

        public virtual void AddParamInDate(string paramName, DateTime paramValue)
        {
            if (paramValue == null)
            {
                paramValue = DateTime.UtcNow;
            }
            SqlParameter param = new SqlParameter(paramName, paramValue)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.DateTime,
                Value = paramValue
            };
            _command.Parameters.Add(param);
        }

        public virtual void AddParamInDateNullable(string paramName, DateTime? paramValue)
        {
            throw new NotImplementedException();
        }

        public virtual void AddParamInDecimal(string paramName, decimal paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramValue)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Decimal,
                Value = paramValue
            };
            _command.Parameters.Add(param);
        }

        public virtual void AddParamInInt32(string paramName, int paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramValue)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                Value = paramValue
            };
            _command.Parameters.Add(param);
        }

        public virtual void AddParamInIntNullable(string paramName, int? paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramValue)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                Value = paramValue
            };
            _command.Parameters.Add(param);
        }

        public virtual void AddParamInInt64(string paramName, long paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramValue)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = paramValue
            };
            _command.Parameters.Add(param);
        }

        public virtual void AddParamInString(string paramName, string paramValue)
        {
            if (paramValue == null)
            {
                paramValue = string.Empty;
            }
            SqlParameter param = new SqlParameter(paramName, paramValue)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                Value = paramValue
            };
            _command.Parameters.Add(param);
        }

        public virtual void AddParamOutInt32(string paramName, int size)
        {
            SqlParameter param = new SqlParameter(paramName, SqlDbType.Int, size)
            {
                Direction = ParameterDirection.Output
            };
            _command.Parameters.Add(param);
        }

        public virtual void AddParamOutDecimal(string paramName, decimal paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramValue)
            {
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Decimal,
                Value = paramValue
            };
            _command.Parameters.Add(param);
        }

        public virtual void AddParamOutString(string paramNamee, int size)
        {
            SqlParameter param = new SqlParameter(paramNamee, SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output,
                Size = size
            };
            _command.Parameters.Add(param);
        }

        public virtual void AddParamOutDate(string paramName)
        {
            throw new NotImplementedException();
        }

        public virtual void AddParamOutRefCursor(string paramName, int size)
        {
            throw new NotImplementedException();
        }

        public virtual void Execute()
        {
            _command.ExecuteNonQuery();
        }

        public virtual DataSet FillDataSet()
        {
            var ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        public virtual string ParamsValue()
        {
            var sb = new StringBuilder();
            foreach (SqlParameter p in _command.Parameters)
            {
                sb.Append("Name :");
                sb.Append(p.ParameterName);
                sb.Append("\n");
                sb.Append("Type : ");
                sb.Append(p.SqlDbType.ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public virtual int GetParamOutInt32(string paramName)
        {
            SqlParameter param = _command.Parameters[paramName] as SqlParameter;
            if (param.Value != DBNull.Value)
            {
                var val = param.Value;
                return Convert.ToInt32(val.ToString());
            }
            return 0;
        }

        public virtual string GetParamOutString(string paramName)
        {
            var param = _command.Parameters[paramName];
            param.Size = 32767;
            return param.Value.ToString();
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
