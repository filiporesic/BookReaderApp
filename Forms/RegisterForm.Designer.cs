namespace BookReaderApp.Forms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.passwordLabela = new System.Windows.Forms.Label();
            this.emailLabela = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.usernameLabela = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.passwordLabela);
            this.panel1.Controls.Add(this.emailLabela);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.registerButton);
            this.panel1.Controls.Add(this.usernameLabela);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.ForeColor = System.Drawing.Color.Salmon;
            this.panel1.Location = new System.Drawing.Point(357, 144);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 600);
            this.panel1.TabIndex = 3;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.WindowText;
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.backButton.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.backButton.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.Red;
            this.backButton.Location = new System.Drawing.Point(58, 350);
            this.backButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(121, 46);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // passwordLabela
            // 
            this.passwordLabela.AutoSize = true;
            this.passwordLabela.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabela.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabela.ForeColor = System.Drawing.Color.Red;
            this.passwordLabela.Location = new System.Drawing.Point(148, 222);
            this.passwordLabela.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabela.Name = "passwordLabela";
            this.passwordLabela.Size = new System.Drawing.Size(153, 39);
            this.passwordLabela.TabIndex = 6;
            this.passwordLabela.Text = "Password";
            // 
            // emailLabela
            // 
            this.emailLabela.AutoSize = true;
            this.emailLabela.BackColor = System.Drawing.Color.Transparent;
            this.emailLabela.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabela.ForeColor = System.Drawing.Color.Red;
            this.emailLabela.Location = new System.Drawing.Point(168, 138);
            this.emailLabela.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLabela.Name = "emailLabela";
            this.emailLabela.Size = new System.Drawing.Size(102, 39);
            this.emailLabela.TabIndex = 5;
            this.emailLabela.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEmail.Location = new System.Drawing.Point(101, 179);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.SystemColors.WindowText;
            this.registerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.registerButton.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.registerButton.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ForeColor = System.Drawing.Color.Red;
            this.registerButton.Location = new System.Drawing.Point(213, 350);
            this.registerButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(121, 46);
            this.registerButton.TabIndex = 2;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // usernameLabela
            // 
            this.usernameLabela.AutoSize = true;
            this.usernameLabela.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabela.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabela.ForeColor = System.Drawing.Color.Red;
            this.usernameLabela.Location = new System.Drawing.Point(148, 55);
            this.usernameLabela.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabela.Name = "usernameLabela";
            this.usernameLabela.Size = new System.Drawing.Size(153, 39);
            this.usernameLabela.TabIndex = 2;
            this.usernameLabela.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Location = new System.Drawing.Point(101, 265);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsername.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUsername.Location = new System.Drawing.Point(101, 98);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::BookReaderApp.Properties.Resources.background_login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1112, 654);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegisterForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label usernameLabela;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label emailLabela;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label passwordLabela;
        public System.Windows.Forms.Button backButton;
    }
}