using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Objects.Data.FrameworkExtensions
{
    public static class EnumExtensions
    {
        /// In the context of this class - an enum 'name' is the actual enum text - eg. MyEnumValue
        /// The 'label' of an enum is the friendly verison of the name, used for display - eg. 'My Enum Value'

        /// <summary>
        /// Returns readable (space separated) enum text value
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <param name="enumValue">Enum value</param>
        /// <returns>Enum text separated by spaces (split on uppercase chars)</returns>
        public static string ToLabel<T>(T enumValue) where T : struct => StringExtensions.SeperateCamelCase(Enum.GetName(typeof(T), enumValue));

        /// <summary>
        /// Returns an enum value that macthes the label passd in.
        /// </summary>
        /// <typeparam name="T">The enum type to convert to</typeparam>
        /// <param name="label">The label version of an enum</param>
        /// <returns>The enum value that matches the label</returns>
        public static T FromLabel<T>(string label) where T : struct => (T)Enum.Parse(typeof(T), label.Replace(StringExtensions.SPACE, String.Empty), true);

        /// <summary>
        /// Gets the name of an enum from an instance of the enum
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <param name="enumValue">The enum value</param>
        /// <returns>The 'name' value of the enum.</returns>
        public static string ToName<T>(T enumValue) where T : struct => Enum.GetName(typeof(T), enumValue);

        /// <summary>
        /// Returns an instance of an enum from the name passed into the function
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <param name="name">The 'name' value of the enum</param>
        /// <returns></returns>
        public static T FromName<T>(string name) where T : struct => (T)Enum.Parse(typeof(T), name);

        public static SqlParameter ToSqlParameter<T>(this T inputParameter, string variableName) where T : IConvertible => ConvertEnumToSqlParameter(inputParameter, variableName);

        public static SqlParameter ConvertEnumToSqlParameter<T>(T inputParameter, string variableName) where T : IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new TypeAccessException("Unsupported Type attempting to wrap in an SqlParameter. Expected 'Enum' got a " + typeof(T).FullName);

            if (String.IsNullOrWhiteSpace(variableName))
                throw new InvalidOperationException("SqlParameter must have a 'name' value");

            return inputParameter.ToString().ToSqlParameter(variableName);
        }


    }
}
