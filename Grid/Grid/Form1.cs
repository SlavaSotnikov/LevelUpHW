using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grid
{
    public partial class Form1 : Form
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;

        public Form1()
        {
            InitializeComponent();

            var connStr = new SqlConnectionStringBuilder
            {
                DataSource = "192.168.1.220, 1433",
                InitialCatalog = "PublicLibrary",
                UserID = "User1",
                Password = "User1",
                Pooling = true
            };
            string sql = "SELECT * FROM Books";
            string sql1 = "SELECT * FROM Writers";
            _connection = new SqlConnection(connStr.ConnectionString);
            
                _connection.Open();
                //SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection);
                //DataSet ds = new DataSet();
                //SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, _connection);
                //DataSet ds1 = new DataSet();
                //adapter.Fill(ds);
                //adapter1.Fill(ds1);
                //DataGridView dataGridView1 = new DataGridView();
                //Controls.Add(dataGridView1);
               // DataGridView dataGridView2 = new DataGridView();
                //Controls.Add(dataGridView2);
                //dataGridView1.DataSource = ds.Tables[0];
                //dataGridView2.DataSource = ds1.Tables[0];
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT Title
                           FROM Writers W
                                RIGHT JOIN BooksWriters BW ON W.WriterId = BW.AuthorId
                                RIGHT JOIN Books B ON BW.BookId = B.BookId
                           WHERE WriterId = 1";
            _adapter = new SqlDataAdapter(sql, _connection);
            DataSet ds = new DataSet();
            _adapter.Fill(ds);

            DataGridView dataGridView1 = new DataGridView();
            Controls.Add(dataGridView1);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
