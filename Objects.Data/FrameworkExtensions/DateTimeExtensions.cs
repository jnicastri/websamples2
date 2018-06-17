using System;
using System.Data;
using System.Data.SqlClient;

namespace Objects.Data.FrameworkExtensions
{
    public static class DateTimeExtensions
    {
        public static SqlParameter ToSqlParameter(this DateTime inputParameter, string variableName) => ConvertDateTimeToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this DateTime? inputParameter, string variableName) => ConvertNullableDateTimeToSqlParameter(inputParameter, variableName);

        public static SqlParameter ConvertDateTimeToSqlParameter(DateTime inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.DateTime
            };
        }

        public static SqlParameter ConvertNullableDateTimeToSqlParameter(DateTime? inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.DateTime
            };
        }
    }
}
