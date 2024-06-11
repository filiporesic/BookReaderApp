﻿namespace BookReaderApp
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
            this.stocksGridView = new System.Windows.Forms.DataGridView();
            this.stockSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateComboBox = new System.Windows.Forms.ComboBox();
            this.WalletButton = new System.Windows.Forms.Button();
            this.PortfolioButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stocksGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // stocksGridView
            // 
            this.stocksGridView.AllowUserToAddRows = false;
            this.stocksGridView.AllowUserToDeleteRows = false;
            this.stocksGridView.AllowUserToResizeColumns = false;
            this.stocksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stocksGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.stocksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stocksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stockSymbol,
            this.stockValue,
            this.valueChange});
            this.stocksGridView.Location = new System.Drawing.Point(1206, 125);
            this.stocksGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stocksGridView.Name = "stocksGridView";
            this.stocksGridView.ReadOnly = true;
            this.stocksGridView.RowHeadersVisible = false;
            this.stocksGridView.RowHeadersWidth = 62;
            this.stocksGridView.RowTemplate.Height = 28;
            this.stocksGridView.Size = new System.Drawing.Size(470, 654);
            this.stocksGridView.TabIndex = 6;
            // 
            // stockSymbol
            // 
            this.stockSymbol.HeaderText = "Stock Symbol";
            this.stockSymbol.MinimumWidth = 8;
            this.stockSymbol.Name = "stockSymbol";
            this.stockSymbol.ReadOnly = true;
            // 
            // stockValue
            // 
            this.stockValue.HeaderText = "Stock Value";
            this.stockValue.MinimumWidth = 8;
            this.stockValue.Name = "stockValue";
            this.stockValue.ReadOnly = true;
            // 
            // valueChange
            // 
            this.valueChange.HeaderText = "Value Change";
            this.valueChange.MinimumWidth = 8;
            this.valueChange.Name = "valueChange";
            this.valueChange.ReadOnly = true;
            // 
            // dateComboBox
            // 
            this.dateComboBox.FormattingEnabled = true;
            this.dateComboBox.Items.AddRange(new object[] {
            "One Day",
            "Two Days",
            "One Week",
            "Two Weeks",
            "One Month",
            "Two Months"});
            this.dateComboBox.Location = new System.Drawing.Point(1206, 826);
            this.dateComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateComboBox.Name = "dateComboBox";
            this.dateComboBox.Size = new System.Drawing.Size(186, 28);
            this.dateComboBox.TabIndex = 7;
            this.dateComboBox.SelectedIndexChanged += new System.EventHandler(this.dateComboBox_SelectedIndexChanged);
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
            // PortfolioButton
            // 
            this.PortfolioButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PortfolioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortfolioButton.Location = new System.Drawing.Point(1503, 952);
            this.PortfolioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PortfolioButton.Name = "PortfolioButton";
            this.PortfolioButton.Size = new System.Drawing.Size(173, 65);
            this.PortfolioButton.TabIndex = 27;
            this.PortfolioButton.Text = "Borrowed books";
            this.PortfolioButton.UseVisualStyleBackColor = false;
            this.PortfolioButton.Click += new System.EventHandler(this.PortfolioButton_Click);
            // 
            // FrontPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1199);
            this.Controls.Add(this.PortfolioButton);
            this.Controls.Add(this.WalletButton);
            this.Controls.Add(this.dateComboBox);
            this.Controls.Add(this.stocksGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrontPage";
            this.Text = "Front Page";
            this.Load += new System.EventHandler(this.FrontPageV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stocksGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView stocksGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueChange;
        private System.Windows.Forms.ComboBox dateComboBox;
        private System.Windows.Forms.Button WalletButton;
        private System.Windows.Forms.Button PortfolioButton;
    }
}