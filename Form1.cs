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



namespace BookReaderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string query = "SELECT * FROM USERS where userId = @userid and username = @username";

            string[] names = { "userid", "username" };
            object[] values = { 1, "test" };
            var dt = DatabaseService.SelectData(query, names, values);

            dataGridView1.DataSource = dt;

        }
    }
}
