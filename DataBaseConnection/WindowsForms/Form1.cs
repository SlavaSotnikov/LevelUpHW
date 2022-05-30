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
using DataBaseConnection;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        private DataBaseAccessor _accessor;

        public Form1(DataBaseAccessor source)
        {
            _accessor = source;

            InitializeComponent();
        }

        public long GetCurrentAuthorId(int row = 0)
        {
            return (long) dataGridView1.Rows[row].Cells["WriterId"].Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _accessor.GetWriters();
            //dataGridView1.Refresh();

           // long writerId = (long)dataGridView1.Rows[0].Cells["WriterId"].Value;
            //int.TryParse(writerId, out int id);

            dataGridView2.DataSource = _accessor.GetBooks(GetCurrentAuthorId());
        }

        private void dataGrid(object sender, DataGridViewCellEventArgs e)
        {
           // long writerId = (long)dataGridView1.Rows[e.RowIndex].Cells["WriterId"].Value;
            //int.TryParse(writerId, out int id);

            //dataGridView1.ind

            dataGridView2.DataSource = _accessor.GetBooks(GetCurrentAuthorId(e.RowIndex));
        }
    }
}
