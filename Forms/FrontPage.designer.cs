namespace BookReaderApp
{
    partial class FrontPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrontPage));
            this.WalletButton = new System.Windows.Forms.Button();
            this.BorrowedButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.borrowBooksGridView = new System.Windows.Forms.DataGridView();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.borrowButton = new System.Windows.Forms.Button();
            this.walletBalance = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.borrowBooksGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // WalletButton
            // 
            this.WalletButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.WalletButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WalletButton.Location = new System.Drawing.Point(1080, 479);
            this.WalletButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.WalletButton.Name = "WalletButton";
            this.WalletButton.Size = new System.Drawing.Size(146, 42);
            this.WalletButton.TabIndex = 26;
            this.WalletButton.Text = "Wallet";
            this.WalletButton.UseVisualStyleBackColor = false;
            this.WalletButton.Click += new System.EventHandler(this.WalletButton_Click);
            // 
            // BorrowedButton
            // 
            this.BorrowedButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BorrowedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowedButton.Location = new System.Drawing.Point(860, 479);
            this.BorrowedButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BorrowedButton.Name = "BorrowedButton";
            this.BorrowedButton.Size = new System.Drawing.Size(146, 42);
            this.BorrowedButton.TabIndex = 27;
            this.BorrowedButton.Text = "Borrowed books";
            this.BorrowedButton.UseVisualStyleBackColor = false;
            this.BorrowedButton.Click += new System.EventHandler(this.BorrowedButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 22);
            this.label1.TabIndex = 35;
            this.label1.Text = "Books available for borrowing, double click for more info:";
            // 
            // borrowBooksGridView
            // 
            this.borrowBooksGridView.AllowUserToAddRows = false;
            this.borrowBooksGridView.AllowUserToDeleteRows = false;
            this.borrowBooksGridView.AllowUserToResizeColumns = false;
            this.borrowBooksGridView.AllowUserToResizeRows = false;
            this.borrowBooksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.borrowBooksGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.borrowBooksGridView.ColumnHeadersHeight = 28;
            this.borrowBooksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.borrowBooksGridView.Location = new System.Drawing.Point(36, 70);
            this.borrowBooksGridView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.borrowBooksGridView.Name = "borrowBooksGridView";
            this.borrowBooksGridView.ReadOnly = true;
            this.borrowBooksGridView.RowHeadersVisible = false;
            this.borrowBooksGridView.RowHeadersWidth = 62;
            this.borrowBooksGridView.RowTemplate.Height = 28;
            this.borrowBooksGridView.Size = new System.Drawing.Size(1190, 338);
            this.borrowBooksGridView.TabIndex = 34;
            this.borrowBooksGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BorrowBooksGridView_CellClick);
            this.borrowBooksGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BorrowBooksGridView_CellDoubleClick);
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(1080, 32);
            this.genreComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(146, 21);
            this.genreComboBox.TabIndex = 36;
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.genreComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(877, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 22);
            this.label2.TabIndex = 37;
            this.label2.Text = "Filer books by genre:";
            // 
            // borrowButton
            // 
            this.borrowButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.borrowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrowButton.Location = new System.Drawing.Point(36, 479);
            this.borrowButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.borrowButton.Name = "borrowButton";
            this.borrowButton.Size = new System.Drawing.Size(111, 41);
            this.borrowButton.TabIndex = 38;
            this.borrowButton.Text = "BORROW";
            this.borrowButton.UseVisualStyleBackColor = false;
            this.borrowButton.Click += new System.EventHandler(this.BorrowButton_Click);
            // 
            // walletBalance
            // 
            this.walletBalance.AutoSize = true;
            this.walletBalance.BackColor = System.Drawing.Color.Transparent;
            this.walletBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.walletBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walletBalance.ForeColor = System.Drawing.Color.White;
            this.walletBalance.Location = new System.Drawing.Point(1042, 423);
            this.walletBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.walletBalance.Name = "walletBalance";
            this.walletBalance.Size = new System.Drawing.Size(156, 24);
            this.walletBalance.TabIndex = 39;
            this.walletBalance.Text = "Wallet balance: ";
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.BackColor = System.Drawing.Color.Transparent;
            this.costLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costLabel.ForeColor = System.Drawing.Color.White;
            this.costLabel.Location = new System.Drawing.Point(33, 423);
            this.costLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(74, 22);
            this.costLabel.TabIndex = 40;
            this.costLabel.Text = "Cost: 0";
            // 
            // FrontPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::BookReaderApp.Properties.Resources.background_login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1265, 611);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.walletBalance);
            this.Controls.Add(this.borrowButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.borrowBooksGridView);
            this.Controls.Add(this.BorrowedButton);
            this.Controls.Add(this.WalletButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FrontPage";
            this.Text = "Front Page";
            this.Load += new System.EventHandler(this.FrontPageV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.borrowBooksGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button WalletButton;
        private System.Windows.Forms.Button BorrowedButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView borrowBooksGridView;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button borrowButton;
        private System.Windows.Forms.Label walletBalance;
        private System.Windows.Forms.Label costLabel;
    }
}