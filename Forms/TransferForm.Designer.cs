﻿namespace BookReaderApp
{
    partial class TransferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferForm));
            this.depositSelector = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.depositButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.depositSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // depositSelector
            // 
            this.depositSelector.Location = new System.Drawing.Point(133, 36);
            this.depositSelector.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.depositSelector.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.depositSelector.Name = "depositSelector";
            this.depositSelector.Size = new System.Drawing.Size(104, 20);
            this.depositSelector.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select the amount to deposit:";
            // 
            // depositButton
            // 
            this.depositButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.depositButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depositButton.Location = new System.Drawing.Point(133, 72);
            this.depositButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.depositButton.Name = "depositButton";
            this.depositButton.Size = new System.Drawing.Size(104, 32);
            this.depositButton.TabIndex = 21;
            this.depositButton.Text = "Deposit";
            this.depositButton.UseVisualStyleBackColor = false;
            this.depositButton.Click += new System.EventHandler(this.depositButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(133, 144);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(104, 32);
            this.closeButton.TabIndex = 25;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(377, 183);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.depositButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.depositSelector);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "TransferForm";
            this.Text = "Deposit";
            this.Load += new System.EventHandler(this.TransactionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.depositSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown depositSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button depositButton;
        private System.Windows.Forms.Button closeButton;
    }
}