using System;
using System.Data;
using System.Data.SqlClient;

namespace Objects.Data.FrameworkExtensions
{
    public static class IntExtensions
    {
        #region SqlParameters

        public static SqlParameter ToSqlParameter(this int inputParameter, string variableName) => ConvertIntToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this short inputParameter, string variableName) => ConvertShortToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this int? inputParameter, string variableName) => ConvertNullableIntToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this short? inputParameter, string variableName) => ConvertNullableShortToSqlParameter(inputParameter, variableName);

        public static SqlParameter ConvertIntToSqlParameter(int inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.Int
            };
        }

        public static SqlParameter ConvertShortToSqlParameter(short inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.SmallInt
            };
        }

        public static SqlParameter ConvertNullableIntToSqlParameter(int? inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.Int
            };
        }

        public static SqlParameter ConvertNullableShortToSqlParameter(short? inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.SmallInt
            };
        }

        #endregion

        public static bool CheckIfNumeric(string sNumber)
        {
            bool IsNum = true;
            if (string.IsNullOrEmpty(sNumber))
            {
                IsNum = false;
            }
            else
            {
                for (int index = 0; index < sNumber.Length; index++)
                {
                    if (!Char.IsNumber(sNumber[index]))
                    {
                        IsNum = false;
                        break;
                    }
                }
            }
            return IsNum;
        }

        public static string PadZeros(this int value, int cols)
        {
            string formatted = value.ToString();
            while (formatted.Length < cols)
            {
                formatted = String.Format("0{0}", formatted);
            }
            return formatted;
        }

        public static int? ParseNullable(string value) => ParseNullable(value, null);

        public static int? ParseNullable(string value, int? defaultValue) => String.IsNullOrEmpty(value) ? defaultValue : Int32.Parse(value);

        public static int? TryParseNullable(string value)
        {
            try
            {
                return ParseNullable(value, null);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public static int? TryParseNullable(string value, int? defaultValue)
        {
            try
            {
                return String.IsNullOrEmpty(value) ? defaultValue : Int32.Parse(value);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }

    public static class Int64Extensions
    {
        #region SqlParams

        public static SqlParameter ToSqlParameter(this long inputParameter, string variableName) => ConvertInt64ToSqlParameter(inputParameter, variableName);

        public static SqlParameter ToSqlParameter(this long? inputParameter, string variableName) => ConvertNullableInt64ToSqlParameter(inputParameter, variableName);

        public static SqlParameter ConvertInt64ToSqlParameter(long inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.BigInt
            };
        }

        public static SqlParameter ConvertNullableInt64ToSqlParameter(long? inputParameter, string variableName)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter)
            {
                SqlDbType = SqlDbType.BigInt
            };
        }

        #endregion

        public static long? ParseNullable(string value) => ParseNullable(value, null);

        public static long? ParseNullable(string value, long? defaultValue) => String.IsNullOrEmpty(value) ? defaultValue : Int64.Parse(value);

        public static long? TryParseNullable(string value)
        {
            try { return ParseNullable(value, null); }
            catch (FormatException) { return null; }
        }

        public static long? TryParseNullable(string value, long? defaultValue)
        {
            try { return ParseNullable(value, defaultValue); }
            catch (FormatException) { return null; }
        }
    }
}
