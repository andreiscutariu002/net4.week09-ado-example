using System;
using System.Data.SqlClient;

namespace DataAccess.Connection
{
    public static class ConnectionManager
    {
        // TODO - keep in configuration file
        private static readonly string ConnectionString = "Data Source=.; Initial Catalog=week08;Integrated Security=True;";

        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            try
            {
                if(connection == null)
                {
                    connection = new SqlConnection
                    {
                        ConnectionString = ConnectionString
                    };

                    connection.Open();
                }

                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error when connecting to database: {e.Message}");
                throw;
            }
        }
    }
}
