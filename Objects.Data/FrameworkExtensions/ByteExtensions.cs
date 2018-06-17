using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Objects.Data.FrameworkExtensions
{
    public static class ByteExtensions
    {
        public static SqlParameter ToSqlParameter(this byte inputParameter, string variableName) => ConvertByteToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this byte? inputParameter, string variableName) => ConvertNullableByteToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this byte[] inputParameter, string variableName) => ConvertByteArrayToSqlParameter(inputParameter, variableName);

        public static SqlParameter ConvertByteToSqlParameter(byte inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.TinyInt
            };
        }

        public static SqlParameter ConvertNullableByteToSqlParameter(byte? inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.TinyInt
            };
        }

        public static SqlParameter ConvertByteArrayToSqlParameter(byte[] inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.VarBinary
            };
        }
    }
}
