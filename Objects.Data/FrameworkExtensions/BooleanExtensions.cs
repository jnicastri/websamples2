using System;
using System.Data;
using System.Data.SqlClient;

namespace Objects.Data.FrameworkExtensions
{
    public static class BooleanExtensions
    {
        public static SqlParameter ToSqlParameter(this bool inputParameter, string variableName) => ConvertBoolToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this bool? inputParameter, string variableName) => ConvertNullableBoolToSqlParameter(inputParameter, variableName);

        public static SqlParameter ConvertBoolToSqlParameter(bool inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.Bit
            };
        }

        public static SqlParameter ConvertNullableBoolToSqlParameter(bool? inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.Bit
            };
        }
    }
}
