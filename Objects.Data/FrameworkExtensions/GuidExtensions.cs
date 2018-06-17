using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Objects.Data.FrameworkExtensions
{
    public static class GuidExtensions
    {
        public static SqlParameter ToSqlParameter(this Guid inputParameter, string variableName) => ConvertGuidToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this Guid? inputParameter, string variableName) => ConvertNullableGuidToSqlParameter(inputParameter, variableName);

        public static SqlParameter ConvertGuidToSqlParameter(Guid inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.UniqueIdentifier
            };
        }

        public static SqlParameter ConvertNullableGuidToSqlParameter(Guid? inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.UniqueIdentifier
            };
        }
    }
}
