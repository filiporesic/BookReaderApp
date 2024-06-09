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
            string password1 = txtPassword1.Text;
            string password2 = txtPassword2.Text;

            if(password1==password2 && !GetUserByName(username))
            {
                User newUser = new User(username, email, password);
                UserService.CreateUser(newUser);
                MessageBox.Show("Registration successful!");
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            if(password1!=password2)
            {
                MessageBox.Show("Passwords do not match!");
            }
            if(GetUserByName(username))
            {
                MessageBox.Show("User already exists!");
            }
        }
    }
}
