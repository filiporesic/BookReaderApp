using System.Drawing;
using System.Windows.Forms;

namespace BookReaderApp
{
    partial class WalletForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridTransactions = new System.Windows.Forms.DataGridView();
            this.walletBalance = new System.Windows.Forms.Label();
            this.borrowBooksGridView = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.borrowComboBox = new System.Windows.Forms.ComboBox();
            this.borrowButton = new System.Windows.Forms.Button();
            this.costLabel = new System.Windows.Forms.Label();
            this.buyResultLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.availableBooksGridView = new System.Windows.Forms.DataGridView();
            this.BookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellResultLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.depositButton = new System.Windows.Forms.Button();
            this.FrontPageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowBooksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableBooksGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTransactions
            // 
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTransactions.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTransactions.Location = new System.Drawing.Point(408, 250);
            this.dataGridTransactions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridTransactions.Name = "dataGridTransactions";
            this.dataGridTransactions.RowHeadersVisible = false;
            this.dataGridTransactions.RowHeadersWidth = 62;
            this.dataGridTransactions.Size = new System.Drawing.Size(1426, 216);
            this.dataGridTransactions.TabIndex = 0;
            // 
            // walletBalance
            // 
            this.walletBalance.AutoSize = true;
            this.walletBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.walletBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walletBalance.Location = new System.Drawing.Point(1678, 218);
            this.walletBalance.Name = "walletBalance";
            this.walletBalance.Size = new System.Drawing.Size(156, 24);
            this.walletBalance.TabIndex = 2;
            this.walletBalance.Text = "Wallet balance: ";
            // 
            // borrowBooksGridView
            // 
            this.borrowBooksGridView.AllowUserToAddRows = false;
            this.borrowBooksGridView.AllowUserToDeleteRows = false;
            this.borrowBooksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.borrowBooksGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.borrowBooksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.borrowBooksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Author,
            this.Price});
            this.borrowBooksGridView.Location = new System.Drawing.Point(408, 544);
            this.borrowBooksGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.borrowBooksGridView.Name = "borrowBooksGridView";
            this.borrowBooksGridView.ReadOnly = true;
            this.borrowBooksGridView.RowHeadersVisible = false;
            this.borrowBooksGridView.RowHeadersWidth = 62;
            this.borrowBooksGridView.RowTemplate.Height = 28;
            this.borrowBooksGridView.Size = new System.Drawing.Size(570, 251);
            this.borrowBooksGridView.TabIndex = 3;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 8;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Author
            // 
            this.Author.HeaderText = "Author";
            this.Author.MinimumWidth = 8;
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 8;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(237, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Books available for borrowing:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1030, 544);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select book to borrow:";
            // 
            // borrowComboBox
            // 
            this.borrowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.borrowComboBox.FormattingEnabled = true;
            this.borrowComboBox.Location = new System.Drawing.Point(1034, 582);
            this.borrowComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.borrowComboBox.Name = "borrowComboBox";
            this.borrowComboBox.Size = new System.Drawing.Size(140, 28);
            this.borrowComboBox.TabIndex = 8;
            this.borrowComboBox.SelectedIndexChanged += new System.EventHandler(this.BorrowComboBox_SelectedIndexChanged);
            // 
            // borrowButton
            // 
            this.borrowButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.borrowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrowButton.Location = new System.Drawing.Point(1034, 645);
            this.borrowButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.borrowButton.Name = "borrowButton";
            this.borrowButton.Size = new System.Drawing.Size(141, 50);
            this.borrowButton.TabIndex = 10;
            this.borrowButton.Text = "BORROW";
            this.borrowButton.UseVisualStyleBackColor = false;
            this.borrowButton.Click += new System.EventHandler(this.BorrowButton_Click);
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costLabel.Location = new System.Drawing.Point(1221, 582);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(74, 22);
            this.costLabel.TabIndex = 11;
            this.costLabel.Text = "Cost: 0";
            // 
            // buyResultLabel
            // 
            this.buyResultLabel.AutoSize = true;
            this.buyResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buyResultLabel.Location = new System.Drawing.Point(1238, 645);
            this.buyResultLabel.Name = "buyResultLabel";
            this.buyResultLabel.Size = new System.Drawing.Size(0, 22);
            this.buyResultLabel.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(237, 834);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(656, 33);
            this.label4.TabIndex = 13;
            this.label4.Text = "Book available for reading, double click to read:";
            // 
            // availableBooksGridView
            // 
            this.availableBooksGridView.AllowUserToAddRows = false;
            this.availableBooksGridView.AllowUserToDeleteRows = false;
            this.availableBooksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.availableBooksGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.availableBooksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availableBooksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookId,
            this.BookTitle,
            this.BookAuthor});
            this.availableBooksGridView.Location = new System.Drawing.Point(408, 870);
            this.availableBooksGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.availableBooksGridView.Name = "availableBooksGridView";
            this.availableBooksGridView.ReadOnly = true;
            this.availableBooksGridView.RowHeadersVisible = false;
            this.availableBooksGridView.RowHeadersWidth = 62;
            this.availableBooksGridView.RowTemplate.Height = 28;
            this.availableBooksGridView.Size = new System.Drawing.Size(570, 191);
            this.availableBooksGridView.TabIndex = 14;
            this.availableBooksGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.availableBooksGridView_CellClick);
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
            // sellResultLabel
            // 
            this.sellResultLabel.AutoSize = true;
            this.sellResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellResultLabel.Location = new System.Drawing.Point(1233, 998);
            this.sellResultLabel.Name = "sellResultLabel";
            this.sellResultLabel.Size = new System.Drawing.Size(0, 22);
            this.sellResultLabel.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(237, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 22);
            this.label7.TabIndex = 23;
            this.label7.Text = "Book borrowing history:";
            // 
            // depositButton
            // 
            this.depositButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.depositButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depositButton.Location = new System.Drawing.Point(408, 1098);
            this.depositButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.depositButton.Name = "depositButton";
            this.depositButton.Size = new System.Drawing.Size(219, 66);
            this.depositButton.TabIndex = 24;
            this.depositButton.Text = "Deposit";
            this.depositButton.UseVisualStyleBackColor = false;
            this.depositButton.Click += new System.EventHandler(this.depositButton_Click);
            // 
            // FrontPageButton
            // 
            this.FrontPageButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FrontPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrontPageButton.Location = new System.Drawing.Point(1377, 1098);
            this.FrontPageButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FrontPageButton.Name = "FrontPageButton";
            this.FrontPageButton.Size = new System.Drawing.Size(176, 66);
            this.FrontPageButton.TabIndex = 29;
            this.FrontPageButton.Text = "Front Page";
            this.FrontPageButton.UseVisualStyleBackColor = false;
            this.FrontPageButton.Click += new System.EventHandler(this.FrontPageButton_Click);
            // 
            // WalletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1199);
            this.Controls.Add(this.FrontPageButton);
            this.Controls.Add(this.depositButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sellResultLabel);
            this.Controls.Add(this.availableBooksGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buyResultLabel);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.borrowButton);
            this.Controls.Add(this.borrowComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.borrowBooksGridView);
            this.Controls.Add(this.walletBalance);
            this.Controls.Add(this.dataGridTransactions);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WalletForm";
            this.Text = "Wallet";
            this.Load += new System.EventHandler(this.WalletForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowBooksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableBooksGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTransactions;
        private System.Windows.Forms.Label walletBalance;
        private System.Windows.Forms.DataGridView borrowBooksGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox borrowComboBox;
        private System.Windows.Forms.Button borrowButton;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.Label buyResultLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView availableBooksGridView;
        private System.Windows.Forms.Label sellResultLabel;
        private System.Windows.Forms.Label label7;
        private Button depositButton;
        private Button FrontPageButton;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn BookId;
        private DataGridViewTextBoxColumn BookTitle;
        private DataGridViewTextBoxColumn BookAuthor;
    }
}

