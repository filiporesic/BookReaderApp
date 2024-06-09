using Amazon.Runtime.Internal.Transform;
using BookReaderApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static MongoDB.Driver.WriteConcern;

namespace BookReaderApp
{
    public partial class WalletForm : Form
    {
        readonly int userId; 
        public WalletForm(int userId)
        {
            this.userId = userId;
            if (WalletService.GetWallet(userId) == null) 
            {
                MessageBox.Show("Error! Please contact our customer support");
                return; //TO DO
            }
            InitializeComponent();

            //Icon = Properties.Resources.icon;
            dataGridTransactions.CellFormatting += DataGridTransactions_CellFormatting; //za uređivanje brojeva transakcija
            FormBorderStyle = FormBorderStyle.FixedSingle;//ne želimo omogućiti korisnicima promjenu veličine prozora
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void DataGridTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int columnIndex = 0;

            if (e.ColumnIndex == columnIndex && e.RowIndex >= 0)
            {
                e.Value = TransformValue(e.Value.ToString());
                e.FormattingApplied = true;
            }
        }

        private string TransformValue(string originalValue)
        {

            String stringValue = int.Parse(originalValue).ToString("X8");
            String transformed = $"TXN-{stringValue}";
            return transformed;
        }

        private void WalletForm_Load(object sender, EventArgs e)
        {
            decimal amount = WalletService.GetWallet(userId).Amount;
            walletBalance.Text = "Wallet balace: " + amount.ToString();

            List<Transaction> transactions = WalletService.GetTransactions(userId);
            
            dataGridTransactions.DataSource = transactions;
            dataGridTransactions.Columns["WalletId"].Visible = false;
            dataGridTransactions.Columns["BookId"].Visible = false;

            costLabel.Text = "Cost: 0";
            availableBooksGridView.Rows.Clear();
            

            var allBooks = WalletService.GetBooks();

            borrowBooksGridView.DataSource = allBooks;
            borrowBooksGridView.Columns["BookId"].Visible = false;

            var borrowedBooks = WalletService.GetBorrowedBooks(userId);
            var uniqueBooks = new Dictionary<int, (int, string, string, int)>();

            foreach (var book in borrowedBooks)
            {
                var daysRemaining = WalletService.GetDaysRemaining(book.Item1, userId);

                if (uniqueBooks.ContainsKey(book.Item1))
                {
                    if (uniqueBooks[book.Item1].Item4 < daysRemaining)
                    {
                        uniqueBooks[book.Item1] = (book.Item1, book.Item2, book.Item3, daysRemaining);
                    }
                }
                else
                {
                    uniqueBooks.Add(book.Item1, (book.Item1, book.Item2, book.Item3, daysRemaining));
                }
            }

            foreach (var book in uniqueBooks.Values)
            {
                object[] row = { book.Item1, book.Item2, book.Item3, WalletService.GetDaysRemaining(book.Item1, userId), BookService.GetBookPrice(book.Item1) };
                availableBooksGridView.Rows.Add(row);
            }

            dataGridTransactions.ClearSelection();
            borrowBooksGridView.ClearSelection();
            availableBooksGridView.ClearSelection();

        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            using(TransferForm transferForm = new TransferForm(userId))
            {
                //nakon uplate ili isplate osvježimo stanje računa
                if(transferForm.ShowDialog() == DialogResult.OK)
                {
                    decimal walletAmount = WalletService.GetWallet(userId).Amount;
                    walletBalance.Text = "Wallet balance: " + walletAmount.ToString();
                }
            }
        }

        private void FrontPageButton_Click(object sender, EventArgs e)
        {
            //FrontPage page = new FrontPage(userId);
            //Hide();
            //page.ShowDialog();
            //Close();
        }

        private void HandleCellClick(object cellValue)
        {
            string filename = BookService.GetBookLocation((int)cellValue);

            ReaderForm reader = new ReaderForm("..\\.." + filename);

            reader.ShowDialog();
        }

        private void ExtendButton_Click(object sender, EventArgs e)
        {
            int row;
            decimal amount;
            DateTime returnDate;
            try
            {
                row = availableBooksGridView.SelectedCells[0].RowIndex;
                amount = (decimal)availableBooksGridView.Rows[row].Cells[4].Value;
            }
            catch
            {
                string message = "Select a book to extend!";
                MessageBox.Show(message);
                return;
            }

            if(extendComboBox.SelectedIndex < 0)
            {
                string message = "Select a period to extend!";
                MessageBox.Show(message);
                return;
            }

            row = availableBooksGridView.SelectedCells[0].RowIndex;
            amount = (decimal)availableBooksGridView.Rows[row].Cells[4].Value;
            int bookId = (int)availableBooksGridView.Rows[row].Cells[0].Value;

            if (extendComboBox.SelectedIndex == 0)
            {
                amount /= 6;
                returnDate = DateTime.Now.Date.AddDays(5+WalletService.GetDaysRemaining(bookId, userId));
            }
            else if (extendComboBox.SelectedIndex == 1)
            {
                amount /= 2;
                returnDate = DateTime.Now.Date.AddDays(15 + WalletService.GetDaysRemaining(bookId, userId));
            }
            else
            {
                returnDate = DateTime.Now.Date.AddDays(WalletService.GetDaysRemaining(bookId, userId));
                returnDate = returnDate.AddMonths(1);
            }

            if (WalletService.GetWallet(userId).Amount >= amount)
            {
                WalletService.UpdateWallet(userId, WalletService.GetWallet(userId).Amount - amount);
                WalletService.CreateTransaction(bookId, userId, WalletService.GetWallet(userId).WalletId, amount, returnDate);
                WalletForm_Load(sender, e);
            }
            else
            {
                string message = "Not enough balance!";
                MessageBox.Show(message);
            }

        }

        private void ExtendComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int row = availableBooksGridView.SelectedCells[0].RowIndex;
                decimal amount = (decimal)availableBooksGridView.Rows[row].Cells[4].Value;

                if (extendComboBox.SelectedIndex == 0)
                {
                    amount /= 6;
                }
                if (extendComboBox.SelectedIndex == 1)
                {
                    amount /= 2;
                }

                extendCostLabel.Text = "Cost: " + amount.ToString();
            }
            catch { }
        }

        private void BorrowBooksGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                decimal price = (decimal)borrowBooksGridView.Rows[e.RowIndex].Cells[3].Value;
                costLabel.Text = "Cost: " + price.ToString();
            }
        }

        private void BorrowButton_Click(object sender, EventArgs e)
        {
            try
            {
                int row = borrowBooksGridView.SelectedCells[0].RowIndex;
                decimal price = (decimal)borrowBooksGridView.Rows[row].Cells[3].Value;
                int bookId = (int)borrowBooksGridView.Rows[row].Cells[0].Value;

                var borrowBooks = WalletService.GetBorrowedBooks(userId);
                foreach(var book in borrowBooks)
                {
                    if (book.Item1 == bookId)
                        return;
                }

                if (WalletService.GetWallet(userId).Amount >= price)
                {
                    DateTime returnDate = DateTime.Now.Date.AddMonths(1);
                    WalletService.UpdateWallet(userId, WalletService.GetWallet(userId).Amount - price);
                    WalletService.CreateTransaction(bookId, userId, WalletService.GetWallet(userId).WalletId, price, returnDate);
                    WalletForm_Load(sender, e);
                }
            }
            catch { }
        }
    }

    
    
}
