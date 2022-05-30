using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        MyDelegate _deleg;
        int _time = 0;

        public Form1()
        {
            InitializeComponent();

            btnMessage.Click += delegate (object sender, EventArgs e)
            {
                MessageBox.Show("Test");
            };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
