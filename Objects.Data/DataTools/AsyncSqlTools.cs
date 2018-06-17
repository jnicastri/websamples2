using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Objects.Data.DataTools
{
    public static class AsyncSqlTools
    {
        public const int SQL_COMMAND_TIME_OUT = 180;

        public static SqlConnection GetNewSqlConnection() => new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        #region ExecuteNonQuery Wrappers

        public static async Task ExecuteNonQueryAsync(string procedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetNewSqlConnection())
            {
                connection.Open();
                await ExecuteNonQueryAsync(connection, procedureName, parameters);
                connection.Close();
            }
        }

        public static async Task ExecuteNonQueryAsync(SqlConnection openConnection, string procedureName, params SqlParameter[] parameters)
        {
            using (SqlCommand command = new SqlCommand(procedureName, openConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = SQL_COMMAND_TIME_OUT;
                command.Parameters.AddRange(parameters ?? new SqlParameter[] { });
                await command.ExecuteNonQueryAsync();
            }
        }

        public static async Task ExecuteNonQueryAsync(string procedureName) => await ExecuteNonQueryAsync(procedureName, null);

        #endregion

        #region ExecuteScalar Wrappers

        public static async Task<object> ExecuteScalarAsync(string procedureName, params SqlParameter[] parameters)
        {
            object scalar;
            using (SqlConnection connection = GetNewSqlConnection())
            {
                connection.Open();
                scalar = await ExecuteScalarAsync(connection, procedureName, parameters);
                connection.Close();
            }
            return scalar;
        }

        public static async Task<object> ExecuteScalarAsync(SqlConnection openConnection, string procedureName, params SqlParameter[] parameters)
        {
            object returnVal;
            using (SqlCommand command = new SqlCommand(procedureName, openConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = SQL_COMMAND_TIME_OUT;
                command.Parameters.AddRange(parameters ?? new SqlParameter[] { });
                returnVal = await command.ExecuteScalarAsync();
            }
            return returnVal;
        }

        #endregion

        #region ExecuteReader Wrappers

        public static async Task ExecuteReaderAsync(string procedureName, SqlParameter[] parameters, Action<SqlDataReader> readerCallback) => await ExecuteReaderAsync(procedureName, parameters, CommandBehavior.Default, readerCallback);

        public static async Task ExecuteReaderAsync(SqlConnection openConnection, string procedureName, SqlParameter[] parameters, Action<SqlDataReader> readerCallback) => await ExecuteReaderAsync(openConnection, procedureName, parameters, CommandBehavior.Default, readerCallback);

        public static async Task ExecuteReaderAsync(string procedureName, SqlParameter[] parameters, CommandBehavior behavior, Action<SqlDataReader> readerCallback)
        {
            using (SqlConnection connection = GetNewSqlConnection())
            {
                connection.Open();
                await ExecuteReaderAsync(connection, procedureName, parameters, behavior, readerCallback);
                connection.Close();
            }
        }

        public static async Task ExecuteReaderAsync(SqlConnection openConnection, string procedureName, SqlParameter[] parameters, CommandBehavior behavior, Action<SqlDataReader> readerCallback)
        {
            using (SqlCommand command = new SqlCommand(procedureName, openConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = SQL_COMMAND_TIME_OUT;
                command.Parameters.AddRange(parameters ?? new SqlParameter[] { });
                SqlDataReader reader = await command.ExecuteReaderAsync(behavior);
                try
                {
                    readerCallback(reader);
                }
                finally
                {
                    if (reader != null) reader.Close();
                }
            }
        }

        #endregion

        #region DataSet Fetcher (not Async)

        public static DataSet GetDataset(string procedureName, SqlParameter[] sqlParams, string datasetName, params string[] tableNames)
        {
            DataSet dataset = new DataSet(datasetName);

            using (SqlConnection connection = GetNewSqlConnection())
            {
                using (SqlCommand command = new SqlCommand(procedureName))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = SQL_COMMAND_TIME_OUT;
                    command.Connection = connection;
                    command.Parameters.AddRange(sqlParams);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataset);
                    int i = 0;
                    foreach (string tableName in tableNames)
                    {
                        dataset.Tables[i++].TableName = tableName;
                    }
                }
            }
            return dataset;
        }

        #endregion
    }
}
