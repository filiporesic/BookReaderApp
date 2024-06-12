using BookReaderApp.Forms;
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
            decimal amount = WalletService.GetBalance(userId);
            walletBalance.Text = "Wallet balace: " + amount.ToString();

            var allBooks = WalletService.GetBooks();

            borrowBooksGridView.DataSource = allBooks;
            borrowBooksGridView.Columns["BookId"].Visible = false;
            borrowBooksGridView.Columns["Other"].Visible = false;

            if (!genreComboBox.Items.Contains("All")) genreComboBox.Items.Add("All");
            foreach (var book in allBooks)
            {
                if (book.Other.Genre != null && !genreComboBox.Items.Contains(book.Other.Genre))
                {
                    genreComboBox.Items.Add(book.Other.Genre);
                }
            }
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

        private void BorrowedButton_Click(object sender, EventArgs e)
        {
            Borrowed wallet = new Borrowed(userId);
            Hide();
            wallet.ShowDialog();
            Close();
        }

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedGenre = genreComboBox.SelectedItem.ToString();
            if (selectedGenre == "All")
            {

                var allBooks = WalletService.GetBooks();

                borrowBooksGridView.DataSource = allBooks;
                borrowBooksGridView.Columns["BookId"].Visible = false;
                borrowBooksGridView.Columns["Other"].Visible = false;

                if (!genreComboBox.Items.Contains("All")) genreComboBox.Items.Add("All");
                foreach (var book in allBooks)
                {
                    if (book.Other.Genre != null && !genreComboBox.Items.Contains(book.Other.Genre))
                    {
                        genreComboBox.Items.Add(book.Other.Genre);
                    }
                }
            }
            else
            {
                var allBooks = WalletService.GetBooks();
                List<Book> filterbooks = allBooks.Where(x => x.Other.Genre == selectedGenre).ToList();

                borrowBooksGridView.DataSource = filterbooks;
                borrowBooksGridView.Columns["BookId"].Visible = false;
                borrowBooksGridView.Columns["Other"].Visible = false;
            }
        }

        private void BorrowBooksGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                decimal price = (decimal)borrowBooksGridView.Rows[e.RowIndex].Cells[4].Value;
                costLabel.Text = "Cost: " + price.ToString();
            }
        }

        private void BorrowButton_Click(object sender, EventArgs e)
        {
            try
            {
                int row = borrowBooksGridView.SelectedCells[0].RowIndex;
                decimal price = (decimal)borrowBooksGridView.Rows[row].Cells[4].Value;
                int bookId = (int)borrowBooksGridView.Rows[row].Cells[0].Value;

                var borrowBooks = WalletService.GetBorrowedBooks(userId);
                foreach (var book in borrowBooks)
                {
                    if (book.BookId == bookId)
                        return;
                }

                if (WalletService.GetBalance(userId) >= price)
                {
                    DateTime returnDate = DateTime.Now.Date.AddMonths(1);
                    WalletService.UpdateWallet(userId, WalletService.GetBalance(userId) - price);
                    WalletService.CreateTransaction(bookId, userId, price, returnDate);
                    FrontPageV2_Load(sender, e);
                }
            }
            catch { }
        }

        private void BorrowBooksGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string title = (string)borrowBooksGridView.Rows[e.RowIndex].Cells[1].Value;
                string author = (string)borrowBooksGridView.Rows[e.RowIndex].Cells[2].Value;
                BookDetails other = (BookDetails)borrowBooksGridView.Rows[e.RowIndex].Cells[3].Value;
                using (InfoForm transferForm = new InfoForm(other, author, title))
                {
                    if (transferForm.ShowDialog() == DialogResult.OK)
                    {
                        
                    }
                }
            }
        }
    }
}
