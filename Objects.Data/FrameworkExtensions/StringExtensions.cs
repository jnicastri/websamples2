using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace Objects.Data.FrameworkExtensions
{
    public static class StringExtensions
    {
        public const string SPACE = " ";
        public const string DEFAULT_DELIMITER = ",";
        public const SqlDbType DEFAULT_STRING_DBTYPE = SqlDbType.NVarChar;

        /// <summary>
        /// Splits a string at Capitalised letters
        /// </summary>
        public static readonly Regex CamelCaseSplitterRegex = new Regex("[a-z]+|[A-Z][a-z]*", RegexOptions.Multiline | RegexOptions.Compiled);

        public static string Join(IEnumerable collection) => Join(DEFAULT_DELIMITER, collection);

        public static string Join(params string[] values) => Join(DEFAULT_DELIMITER, values);

        public static string Join(string seperator, params string[] values) => Join(seperator, (IEnumerable)values);

        public static string Join(string seperator, IEnumerable collection)
        {
            StringBuilder b = new StringBuilder();
            IEnumerator enumerator = collection.GetEnumerator();
            if (enumerator.MoveNext())
            {
                b.Append(enumerator.Current);
                while (enumerator.MoveNext())
                {
                    b.Append(seperator + enumerator.Current);
                }
            }
            return b.ToString().Trim();
        }

        public static string Join(string keyValueSeperator, string pairSeperator, IDictionary dictionary)
        {
            StringBuilder b = new StringBuilder();
            IDictionaryEnumerator enumerator = dictionary.GetEnumerator();
            if (enumerator.MoveNext())
            {
                b.Append(string.Format("{0}{1}{2}", enumerator.Key, keyValueSeperator, enumerator.Value));
                while (enumerator.MoveNext())
                {
                    b.Append(string.Format("{0}{1}{2}{3}", pairSeperator, enumerator.Key, keyValueSeperator, enumerator.Value));
                }
            }
            return b.ToString().Trim();
        }

        public static SqlParameter ToSqlParameter(this char inputParameter, string variableName) => StringExtensions.ConvertToSqlParameter(inputParameter.ToString(), variableName, DEFAULT_STRING_DBTYPE);

        public static SqlParameter ToSqlParameter(this char? inputParameter, string variableName) => StringExtensions.ConvertToSqlParameter(inputParameter?.ToString(), variableName, DEFAULT_STRING_DBTYPE);

        public static SqlParameter ToSqlParameter(this string inputParameter, string variableName) => StringExtensions.ConvertToSqlParameter(inputParameter, variableName, DEFAULT_STRING_DBTYPE);

        public static SqlParameter ToSqlParameter(this string inputParameter, string variableName, SqlDbType sqlDbType) => StringExtensions.ConvertToSqlParameter(inputParameter, variableName, sqlDbType);

        public static SqlParameter ConvertToSqlParameter(string inputParameter, string variableName, SqlDbType sqlDbType)
        {
            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return new SqlParameter(variableName.Trim().StartsWith("@") ? variableName.Trim() : "@" + variableName.Trim(), inputParameter?.Trim())
            {
                SqlDbType = sqlDbType
            };
        }

        /// <summary>
        /// Returns a single space delimited version of a camel case string. Splits on uppercase letters.
        /// </summary>
        /// <param name="input">The string to seperate.</param>
        /// <returns>'input' with spaces inserted between capitalised words.</returns>
        public static string SeperateCamelCase(string input) => SeperateCamelCase(input, SPACE);

        /// <summary>
        /// Returns a 'separator' delimited version of a camel case string. Splits on uppercase letters.
        /// </summary>
        /// <param name="input">The string to seperate.</param>
        /// <param name="seperator">The seperator to insert between capitalised words.</param>
        /// <returns>'input' with 'seperator' inserted between capitalised words.</returns>
        public static string SeperateCamelCase(string input, string seperator) => CamelCaseSplitterRegex.Replace(input, seperator + "$&").Trim();

        public static string[] SplitCamelCase(string input) => GetArrayOfMatches(CamelCaseSplitterRegex, input);

        public static string[] GetArrayOfMatches(Regex regex, string input)
        {
            MatchCollection matches = regex.Matches(input);
            string[] output = new string[matches.Count];
            int i = 0;
            foreach (Match match in matches)
            {
                output[i++] = match.Value;
            }
            return output;
        }

        /// <summary>
        /// Overloaded method to split string into a list of trimmed strings using a comma as a delimiter
        /// </summary>
        /// <param name="val">String to split</param>
        /// <returns></returns>
        public static List<string> SplitToList(string val) => SplitToList(val, new char[] { char.Parse(",") });

        /// <summary>
        /// Splits a delimited string into a list of strings
        /// </summary>
        /// <param name="val">string to split</param>
        /// <param name="delim">Delimiter to split on</param>
        /// <returns></returns>
        public static List<string> SplitToList(string val, params char[] delim)
        {
            List<string> thisList = new List<string>();
            if (val != null && val.Length > 0)
            {
                string[] tmp = val.Split(delim);
                for (int i = 0; i < tmp.Length; i++)
                {
                    thisList.Add(tmp[i].Trim());
                }
            }
            return thisList;
        }

        /// <summary>
        /// Checks that a non-null or empty string contains only alphabetical chars
        /// </summary>
        /// <param name="val">Input string</param>
        /// <returns></returns>
        public static bool IsAlphabetical(this string val)
        {
            if (String.IsNullOrWhiteSpace(val)) return false;
            Regex reg = new Regex(@"^[a-zA-Z]+$");
            return reg.IsMatch(val);
        }

        /// <summary>
        /// Checks a non-null or empty string contains alpha numeric characters only.
        /// Will not accept decimal values
        /// </summary>
        /// <param name="val">String to check</param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(this string val)
        {
            if (String.IsNullOrWhiteSpace(val)) return false;
            Regex reg = new Regex(@"^[a-zA-Z0-9]");
            return reg.IsMatch(val);
        }

        /// <summary>
        /// Checks a string is not null and numeric characters. Will accept
        /// positive or negative floating point values
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string val)
        {
            if (string.IsNullOrEmpty(val)) return false;
            Regex reg = new Regex(@"^[0-9]*$");
            return reg.IsMatch(val);
        }

        /// <summary>
        /// Wraps a string so that it begins with "<![CDATA[" and ends with "]]>".
        /// </summary>
        /// <param name="input">The string to wrap in CDATA tags.</param>
        /// <returns></returns>
        public static string ToXmlCDataString(this string input) => "<![CDATA[" + input + "]]>";

        public static string Remove(string value, params string[] stringsToRemove)
        {
            foreach (string toRemove in stringsToRemove)
            {
                value = Regex.Replace(value, toRemove, String.Empty);
            }
            return value;
        }
    }
}
