namespace BookReaderApp.Forms
{
    partial class Borrowed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Borrowed));
            this.availableBooksGridView = new System.Windows.Forms.DataGridView();
            this.FrontPageButton = new System.Windows.Forms.Button();
            this.WalletButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.pdfViewer1 = new Spire.PdfViewer.Forms.PdfViewer();
            this.bookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.availableBooksGridView)).BeginInit();
            this.SuspendLayout();
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
            this.bookId,
            this.BookTitle,
            this.BookAuthor,
            this.remaining});
            this.availableBooksGridView.Location = new System.Drawing.Point(39, 113);
            this.availableBooksGridView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.availableBooksGridView.Name = "availableBooksGridView";
            this.availableBooksGridView.ReadOnly = true;
            this.availableBooksGridView.RowHeadersVisible = false;
            this.availableBooksGridView.RowHeadersWidth = 62;
            this.availableBooksGridView.RowTemplate.Height = 28;
            this.availableBooksGridView.Size = new System.Drawing.Size(380, 338);
            this.availableBooksGridView.TabIndex = 15;
            this.availableBooksGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvailableBooksGridView_CellClick);
            this.availableBooksGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvailableBooksGridView_CellDoubleClick);
            // 
            // FrontPageButton
            // 
            this.FrontPageButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FrontPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrontPageButton.Location = new System.Drawing.Point(39, 557);
            this.FrontPageButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.FrontPageButton.Name = "FrontPageButton";
            this.FrontPageButton.Size = new System.Drawing.Size(117, 43);
            this.FrontPageButton.TabIndex = 30;
            this.FrontPageButton.Text = "Front Page";
            this.FrontPageButton.UseVisualStyleBackColor = false;
            this.FrontPageButton.Click += new System.EventHandler(this.FrontPageButton_Click);
            // 
            // WalletButton
            // 
            this.WalletButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.WalletButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WalletButton.Location = new System.Drawing.Point(304, 558);
            this.WalletButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.WalletButton.Name = "WalletButton";
            this.WalletButton.Size = new System.Drawing.Size(115, 42);
            this.WalletButton.TabIndex = 31;
            this.WalletButton.Text = "Wallet";
            this.WalletButton.UseVisualStyleBackColor = false;
            this.WalletButton.Click += new System.EventHandler(this.WalletButton_Click);
            // 
            // label4
            // 
            this.label4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(384, 51);
            this.label4.TabIndex = 32;
            this.label4.Text = "Select book to read, double click for more info:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 466);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 22);
            this.label2.TabIndex = 39;
            this.label2.Text = "Filer books by genre:";
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(39, 501);
            this.genreComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(146, 21);
            this.genreComboBox.TabIndex = 38;
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.genreComboBox_SelectedIndexChanged);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.CanPrint = false;
            this.pdfViewer1.CanSave = false;
            this.pdfViewer1.CausesValidation = false;
            this.pdfViewer1.FindTextHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))), ((int)(((byte)(218)))));
            this.pdfViewer1.FormFillEnabled = false;
            this.pdfViewer1.IgnoreCase = false;
            this.pdfViewer1.IsToolBarVisible = false;
            this.pdfViewer1.Location = new System.Drawing.Point(440, 51);
            this.pdfViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.pdfViewer1.MultiPagesThreshold = 60;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OnRenderPageExceptionEvent = null;
            this.pdfViewer1.Size = new System.Drawing.Size(832, 606);
            this.pdfViewer1.TabIndex = 40;
            this.pdfViewer1.Text = "pdfViewer1";
            this.pdfViewer1.Threshold = 60;
            this.pdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // bookId
            // 
            this.bookId.HeaderText = "BookId";
            this.bookId.MinimumWidth = 8;
            this.bookId.Name = "bookId";
            this.bookId.ReadOnly = true;
            this.bookId.Visible = false;
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
            // Borrowed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1283, 779);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.WalletButton);
            this.Controls.Add(this.FrontPageButton);
            this.Controls.Add(this.availableBooksGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Borrowed";
            this.Text = "Borrowed";
            this.Load += new System.EventHandler(this.Borrowed_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.availableBooksGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView availableBooksGridView;
        private System.Windows.Forms.Button FrontPageButton;
        private System.Windows.Forms.Button WalletButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox genreComboBox;
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn remaining;
    }
}