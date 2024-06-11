using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookReaderApp.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LoginForm page = new LoginForm();
            Hide();
            page.ShowDialog();
            Close();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            User reg = new User(username, email, password);

            // create new user
            string query = "INSERT INTO Users (Username, Email, PasswordHash) values" +
                "(@Username, @Email, @PasswordHash);";

            string[] names = { "Username", "Email", "PasswordHash" };
            object[] values = { username, email, PasswordManager.ComputeSha256Hash(password) };

            DatabaseService.RunQuery(query, names, values);

            LoginForm page = new LoginForm();
            Hide();
            page.ShowDialog();
            Close();
        }
    }
}
