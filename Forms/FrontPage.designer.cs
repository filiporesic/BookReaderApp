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
            this.WalletButton = new System.Windows.Forms.Button();
            this.BorrowedButton = new System.Windows.Forms.Button();
            this.availableBooksGridView = new System.Windows.Forms.DataGridView();
            this.BookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.borrowBooksGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.availableBooksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowBooksGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // WalletButton
            // 
            this.WalletButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.WalletButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WalletButton.Location = new System.Drawing.Point(1206, 952);
            this.WalletButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WalletButton.Name = "WalletButton";
            this.WalletButton.Size = new System.Drawing.Size(173, 65);
            this.WalletButton.TabIndex = 26;
            this.WalletButton.Text = "Wallet";
            this.WalletButton.UseVisualStyleBackColor = false;
            this.WalletButton.Click += new System.EventHandler(this.WalletButton_Click);
            // 
            // BorrowedButton
            // 
            this.BorrowedButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BorrowedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowedButton.Location = new System.Drawing.Point(1503, 952);
            this.BorrowedButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BorrowedButton.Name = "BorrowedButton";
            this.BorrowedButton.Size = new System.Drawing.Size(173, 65);
            this.BorrowedButton.TabIndex = 27;
            this.BorrowedButton.Text = "Borrowed books";
            this.BorrowedButton.UseVisualStyleBackColor = false;
            this.BorrowedButton.Click += new System.EventHandler(this.BorrowedButton_Click);
            // 
            // availableBooksGridView
            // 
            this.availableBooksGridView.AllowUserToAddRows = false;
            this.availableBooksGridView.AllowUserToDeleteRows = false;
            this.availableBooksGridView.AllowUserToResizeColumns = false;
            this.availableBooksGridView.AllowUserToResizeRows = false;
            this.availableBooksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.availableBooksGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.availableBooksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availableBooksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookId,
            this.BookTitle,
            this.BookAuthor,
            this.remaining,
            this.cost});
            this.availableBooksGridView.Location = new System.Drawing.Point(1503, 310);
            this.availableBooksGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.availableBooksGridView.Name = "availableBooksGridView";
            this.availableBooksGridView.ReadOnly = true;
            this.availableBooksGridView.RowHeadersVisible = false;
            this.availableBooksGridView.RowHeadersWidth = 62;
            this.availableBooksGridView.RowTemplate.Height = 28;
            this.availableBooksGridView.Size = new System.Drawing.Size(570, 520);
            this.availableBooksGridView.TabIndex = 28;
            // 
            // BookId
            // 
            this.BookId.HeaderText = "BookId";
            this.BookId.MinimumWidth = 8;
            this.BookId.Name = "BookId";
            this.BookId.ReadOnly = true;
            this.BookId.Visible = false;
            // 
            // BookTitle
            // 
            this.BookTitle.HeaderText = "Title";
            this.BookTitle.MinimumWidth = 8;
            this.BookTitle.Name = "BookTitle";
            this.BookTitle.ReadOnly = true;
            // 
            // BookAuthor
            // 
            this.BookAuthor.HeaderText = "Author";
            this.BookAuthor.MinimumWidth = 8;
            this.BookAuthor.Name = "BookAuthor";
            this.BookAuthor.ReadOnly = true;
            // 
            // remaining
            // 
            this.remaining.HeaderText = "Days Remaining";
            this.remaining.MinimumWidth = 8;
            this.remaining.Name = "remaining";
            this.remaining.ReadOnly = true;
            // 
            // cost
            // 
            this.cost.HeaderText = "Price";
            this.cost.MinimumWidth = 8;
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            this.cost.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1499, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 22);
            this.label4.TabIndex = 33;
            this.label4.Text = "Borrowed books:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(868, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 22);
            this.label1.TabIndex = 35;
            this.label1.Text = "Books available for borrowing:";
            // 
            // borrowBooksGridView
            // 
            this.borrowBooksGridView.AllowUserToAddRows = false;
            this.borrowBooksGridView.AllowUserToDeleteRows = false;
            this.borrowBooksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.borrowBooksGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.borrowBooksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.borrowBooksGridView.Location = new System.Drawing.Point(872, 310);
            this.borrowBooksGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.borrowBooksGridView.Name = "borrowBooksGridView";
            this.borrowBooksGridView.ReadOnly = true;
            this.borrowBooksGridView.RowHeadersVisible = false;
            this.borrowBooksGridView.RowHeadersWidth = 62;
            this.borrowBooksGridView.RowTemplate.Height = 28;
            this.borrowBooksGridView.Size = new System.Drawing.Size(570, 520);
            this.borrowBooksGridView.TabIndex = 34;
            // 
            // FrontPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1199);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.borrowBooksGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.availableBooksGridView);
            this.Controls.Add(this.BorrowedButton);
            this.Controls.Add(this.WalletButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrontPage";
            this.Text = "Front Page";
            this.Load += new System.EventHandler(this.FrontPageV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.availableBooksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowBooksGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button WalletButton;
        private System.Windows.Forms.Button BorrowedButton;
        private System.Windows.Forms.DataGridView availableBooksGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn remaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView borrowBooksGridView;
    }
}