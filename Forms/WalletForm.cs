using BookReaderApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

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
            walletBalance.Text += amount.ToString();

            /*var stocks = WalletService.GetAvailableStocksWithValues();

            foreach(var stock in stocks)
            {
                string[] row = {stock.Key, stock.Value.ToString()};
                buyComboBox.Items.Add(stock.Key);
                buyStocksGridView.Rows.Add(row);
            }*/
          

            List<Transaction> transactions = WalletService.GetTransactions(userId);
            
            dataGridTransactions.DataSource = transactions;
            dataGridTransactions.Columns["WalletId"].Visible = false;
            dataGridTransactions.Columns["BookId"].Visible = false;

            var borrowedBooks = WalletService.GetBorrowedBooks(userId);
            foreach (var valuePair in borrowedBooks)
            {
                object[] row = { valuePair.Key, valuePair.Value.Item1, valuePair.Value.Item2};
                availableBooksGridView.Rows.Add(row);
            }


            dataGridTransactions.ClearSelection();
            borrowBooksGridView.ClearSelection();
            availableBooksGridView.ClearSelection();
        }

        private void BorrowComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String book = borrowComboBox.Text;
            var books = WalletService.GetBooksWithPrices();
            try
            {
                decimal value = books[book];
                costLabel.Text = "Cost: " + value.ToString();
            }
            catch
            {
                costLabel.Text = "Cost: 0";
            }
        }

        private void BorrowButton_Click(object sender, EventArgs e)
        {
            /*decimal amount = buyAmountSelector.Value;
            if (amount > 0)
            {
                String stock = borrowComboBox.Text;

                bool successful = WalletService.BuyStock(userId, stock, amount);
                if (successful)
                {
                    decimal walletAmount = WalletService.GetWallet(userId).Amount;
                    walletBalance.Text = "Wallet balance: " + walletAmount.ToString();
                    buyResultLabel.Text = "Stocks bought successfully.";
                    sellStocksGridView.Rows.Clear();
                    List<StockOwnership> sellStocks = WalletService.GetOwnedStocks(userId);
                    var stocks = WalletService.GetAvailableStocksWithValues();
                    sellComboBox.Items.Clear();

                    foreach (StockOwnership s in sellStocks)
                    {
                        if(s.Quantity > 0)
                        {
                            decimal value = s.Quantity * stocks[s.StockSymbol];
                            string[] row = { s.StockSymbol, s.Quantity.ToString(), stocks[s.StockSymbol].ToString(), value.ToString() };
                            sellComboBox.Items.Add(s.StockSymbol);
                            sellStocksGridView.Rows.Add(row);
                        }
                    }
                    //poruku prikazujemo samo na nekoliko sekundi
                    System.Timers.Timer timer = new System.Timers.Timer(2000);
                    timer.Elapsed += (_, __) => buyResultLabel.Invoke((MethodInvoker)(() => buyResultLabel.Text = ""));
                    timer.AutoReset = false;
                    timer.Start();
                    TransactionComboBox_SelectedIndexChanged(sender, e);
                }
                else
                {
                    //poruku prikazujemo samo na nekoliko sekundi
                    buyResultLabel.Text = "Stocks not bought. Try again.";
                    System.Timers.Timer timer = new System.Timers.Timer(2000);
                    timer.Elapsed += (_, __) => buyResultLabel.Invoke((MethodInvoker)(() => buyResultLabel.Text = ""));
                    timer.AutoReset = false;
                    timer.Start();
                }
            }*/
        }

        private void depositButton_Click(object sender, EventArgs e)
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

        private void availableBooksGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cellValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;
                HandleCellClick(cellValue);
            }
        }

        private void HandleCellClick(object cellValue)
        {
            string filename = BookService.GetBookLocation((int)cellValue);

            ReaderForm reader = new ReaderForm("..\\.." + filename);

            reader.ShowDialog();
        }
    }

    
    
}
