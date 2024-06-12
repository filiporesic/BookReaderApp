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
            availableBooksGridView.Rows.Clear();

            var borrowedBooks = WalletService.GetBorrowedBooks(userId);
            var uniqueBooks = new Dictionary<int, (Book, int)>();

            foreach (var book in borrowedBooks)
            {
                var daysRemaining = WalletService.GetDaysRemaining(book.BookId, userId);

                if (uniqueBooks.ContainsKey(book.BookId))
                {
                    if (uniqueBooks[book.BookId].Item2 < daysRemaining)
                    {
                        uniqueBooks[book.BookId] = (book, daysRemaining);
                    }
                }
                else
                {
                    uniqueBooks.Add(book.BookId, (book, daysRemaining));
                }
            }

            foreach (var book in uniqueBooks.Values)
            {
                object[] row = { book.Item1.Title, book.Item1.Author, WalletService.GetDaysRemaining(book.Item1.BookId, userId) };
                availableBooksGridView.Rows.Add(row);
            }

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
                availableBooksGridView.Rows.Clear();

                var borrowedBooks = WalletService.GetBorrowedBooks(userId);
                var uniqueBooks = new Dictionary<int, (Book, int)>();

                foreach (var book in borrowedBooks)
                {
                    var daysRemaining = WalletService.GetDaysRemaining(book.BookId, userId);

                    if (uniqueBooks.ContainsKey(book.BookId))
                    {
                        if (uniqueBooks[book.BookId].Item2 < daysRemaining)
                        {
                            uniqueBooks[book.BookId] = (book, daysRemaining);
                        }
                    }
                    else
                    {
                        uniqueBooks.Add(book.BookId, (book, daysRemaining));
                    }
                }

                foreach (var book in uniqueBooks.Values)
                {
                    object[] row = { book.Item1.Title, book.Item1.Author, WalletService.GetDaysRemaining(book.Item1.BookId, userId) };
                    availableBooksGridView.Rows.Add(row);
                }

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
                availableBooksGridView.Rows.Clear();

                var borrowedBooks = WalletService.GetBorrowedBooks(userId);
                var uniqueBooks = new Dictionary<int, (Book, int)>();

                foreach (var book in borrowedBooks)
                {
                    var daysRemaining = WalletService.GetDaysRemaining(book.BookId, userId);

                    if (uniqueBooks.ContainsKey(book.BookId))
                    {
                        if (uniqueBooks[book.BookId].Item2 < daysRemaining && book.Other.Genre == selectedGenre)
                        {
                            uniqueBooks[book.BookId] = (book, daysRemaining);
                        }
                    }
                    else
                    {
                        uniqueBooks.Add(book.BookId, (book, daysRemaining));
                    }
                }

                foreach (var book in uniqueBooks.Values)
                {
                    object[] row = { book.Item1.Title, book.Item1.Author, WalletService.GetDaysRemaining(book.Item1.BookId, userId) };
                    if (book.Item1.Other.Genre == selectedGenre)
                    {
                        availableBooksGridView.Rows.Add(row);
                    }
                }

                var allBooks = WalletService.GetBooks();
                List<Book> filterbooks = allBooks.Where(x => x.Other.Genre == selectedGenre).ToList();

                borrowBooksGridView.DataSource = filterbooks;
                borrowBooksGridView.Columns["BookId"].Visible = false;
                borrowBooksGridView.Columns["Other"].Visible = false;
            }
        }
    }
}
