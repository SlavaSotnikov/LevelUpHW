using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseConnection;

namespace WindowsForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (DataBaseAccessor dataBase = new DataBaseAccessor(ConnectDB.GetString()))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(dataBase));
            }
        }
    }
}
