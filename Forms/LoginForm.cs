using System;
using System.Windows.Forms;

namespace BookReaderApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = UserService.GetUserByName(username);

            if (VerifyPasswordHash(password, user.PasswordHash))
            {
                MessageBox.Show("Login successful!");
                //sto dalje ide
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm RegisterForm = new RegisterForm();
            RegisterForm.Show();
            this.Hide();
        }
    }
}
