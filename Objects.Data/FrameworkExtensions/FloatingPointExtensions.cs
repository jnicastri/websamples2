using System;
using System.Data;
using System.Data.SqlClient;

namespace Objects.Data.FrameworkExtensions
{
    public static class FloatingPointExtensions
    {
        #region Decimal

        public static SqlParameter ToSqlParameter(this decimal inputParameter, string variableName) => ConvertDecimalToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this decimal? inputParameter, string variableName) => ConvertNullableDecimalToSqlParameter(inputParameter, variableName);

        public static SqlParameter ConvertDecimalToSqlParameter(decimal inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.Decimal
            };
        }

        public static SqlParameter ConvertNullableDecimalToSqlParameter(decimal? inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.Decimal
            };
        }

        #endregion

        #region Double

        public static SqlParameter ToSqlParameter(this double inputParameter, string variableName) => ConvertDoubleToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this double? inputParameter, string variableName) => ConvertNullableDoubleToSqlParameter(inputParameter, variableName);

        public static SqlParameter ConvertDoubleToSqlParameter(double inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.Float
            };
        }

        public static SqlParameter ConvertNullableDoubleToSqlParameter(double? inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.Float
            };
        }

        #endregion
    }
}
