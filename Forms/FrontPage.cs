using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookReaderApp
{
    // ovdje je i popis posudjenih i "store"
    // ideja: kod generiranja posudjenih gledamo sve u tablici transactions
    //        sa njegovim imenom i filtriramo tako da pogledamo jel danasnji datum
    //        <= return date-a
    // tako imamo povijest transakcija, a user ne mora manualno "vracati"

    // dakle ova stranica je samo vizualna i nemoze na njoj nista raditi nego samo da kao vidi kaj ima svoje i kaj ima u trgovini

    // ima dosta koda kojeg treba obrisat al to cemo kad napravimo izgled tek
    public partial class FrontPage : Form
    {

        readonly int userId;
        public FrontPage(int userId)
        {
            this.userId = userId; // postavlja identifikator korisnika na lokanu varijablu
            InitializeComponent();
            InitUI();

            FormClosing += FrontPage_FormClosing;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            MinimizeBox = false;

        }

        private void FrontPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void FrontPageV2_Load(object sender, EventArgs e)
        {
            dateComboBox.SelectedIndex = 0;
            DateTime date = DateTime.UtcNow.Date;
            DateTime yesterday = date.AddDays(-1);
            //var stocks = BrokerService.GetAllStocksByDate(date);
            /*foreach ( var stock in stocks )
            {
                Stock yesterdayStock = BrokerService.GetStockInfo(stock.Symbol, yesterday);
                decimal difference = stock.Price - yesterdayStock.Price;
                string[] row = {stock.Symbol, stock.Price.ToString(),  difference.ToString()};
                int rowIndex = stocksGridView.Rows.Add(row);
                DataGridViewCell cell = stocksGridView.Rows[rowIndex].Cells[2];

                cell.Style.ForeColor = difference > 0 ? Color.Green : (difference < 0 ? Color.Red : Color.Black);
            }*/
        }

        private void dateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DateTime today = DateTime.UtcNow.Date;
            //DateTime date = DateTime.UtcNow.Date.AddDays(-1);
            //var stocks = BrokerService.GetAllStocksByDate(today);
            //stocksGridView.Rows.Clear();
            
            //if (dateComboBox.SelectedIndex == 0)
            //{
            //    date = today.AddDays(-1);
            //}
            //if (dateComboBox.SelectedIndex == 1)
            //{
            //    date = today.AddDays(-2);
            //}
            //if (dateComboBox.SelectedIndex == 2)
            //{
            //    date = today.AddDays(-7);
            //}
            //if (dateComboBox.SelectedIndex == 3)
            //{
            //    date = today.AddDays(-14);
            //}
            //if (dateComboBox.SelectedIndex == 3)
            //{
            //    date = today.AddMonths(-1);
            //}
            //if (dateComboBox.SelectedIndex == 4)
            //{
            //    date = today.AddMonths(-2);
            //}


            //foreach (var stock in stocks)
            //{
            //    Stock lastStock = BrokerService.GetStockInfo(stock.Symbol, date);
            //    decimal difference = stock.Price - lastStock.Price;
            //    string[] row = { stock.Symbol, stock.Price.ToString(), difference.ToString() };
            //    int rowIndex = stocksGridView.Rows.Add(row);
            //    DataGridViewCell cell = stocksGridView.Rows[rowIndex].Cells[2];

            //    cell.Style.ForeColor = difference > 0 ? Color.Green : (difference < 0 ? Color.Red : Color.Black);
            //}
        }


        // Sluzi za dodavanje podataka u pie chart i u graf s podatcima o dionicama
        public void InitUI()
        {
        }

        private void WalletButton_Click(object sender, EventArgs e)
        {
            WalletForm wallet = new WalletForm(userId);
            Hide();
            wallet.ShowDialog();
            Close();
        }

        private void PortfolioButton_Click(object sender, EventArgs e)
        {
            //Portfolio portfolio = new Portfolio(userId);
            //Hide();
            //portfolio.ShowDialog();
            //Close();
        }
    }
}
