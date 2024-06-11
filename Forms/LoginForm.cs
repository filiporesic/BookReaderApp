using BookReaderApp.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BookReaderApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            FormClosing += LoginForm_FormClosing;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true;
            Controls.Add(panel1);
        }

        /// <summary>
        /// Checks password and opens front page form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            var user = UserService.LogIn(username, password);

            if (user != null)
            {
                FrontPage frontPage = new FrontPage(user.UserId);
                Hide();
                frontPage.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Unable to log in. Check your username or password.");
            }
        }
        /// <summary>
        /// Shows form for creating new user and hides current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Size = this.Size;
            registerForm.Location = this.Location;
            registerForm.WindowState = this.WindowState;
            Hide();
            registerForm.ShowDialog();
        }
    }
}
