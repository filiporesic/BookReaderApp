using System;
using System.Windows.Forms;

namespace BookReaderApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            User newUser = new User(username, email, password);

            UserService.CreateUser(newUser);
            MessageBox.Show("Registration successful!");

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
            
        }
    }
}
