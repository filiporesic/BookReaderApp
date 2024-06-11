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

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password1 = txtPassword1.Text;
            string password2 = txtPassword2.Text;

            if(password1==password2 && UserService.GetUserByName(username) != new User())
            {
                User newUser = new User(username, email, password1);
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
            if(UserService.GetUserByName(username) != new User())
            {
                MessageBox.Show("User already exists!");
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RegisterForm
            // 
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1199);
            this.Name = "RegisterForm";
            this.ResumeLayout(false);

        }
    }
}
