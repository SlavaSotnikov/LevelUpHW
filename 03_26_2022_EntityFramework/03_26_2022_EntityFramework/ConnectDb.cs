using System.Data.SqlClient;

namespace _03_26_2022_EntityFramework
{
    internal class ConnectDb
    {
        public static string GetString()
        {
            var connStr = new SqlConnectionStringBuilder
            {
                DataSource = "192.168.1.220, 1433",
                InitialCatalog = "PublicLibrary",
                UserID = "User1",
                Password = "User1",
                Pooling = true
            };

            return connStr.ConnectionString;
        }
    }
}
