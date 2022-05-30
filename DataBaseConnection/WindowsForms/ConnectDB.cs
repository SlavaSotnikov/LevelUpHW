using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    internal static class ConnectDB
    {
        public static string GetString()
        {
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder
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
