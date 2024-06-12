using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookReaderApp.Forms
{
    public partial class Borrowed : Form
    {
        readonly int userId;
        public Borrowed(int userId)
        {
            this.userId = userId;

            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            MinimizeBox = false;
        }
        // ovdje ce bit sve posudjene knjige
        // sort po zanru i moze birat koju ce citat
        private void Borrowed_Load_1(object sender, EventArgs e)
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
                object[] row = { book.Item1.Author, book.Item1.Title, WalletService.GetDaysRemaining(book.Item1.BookId, userId), BookService.GetBookPrice(book.Item1.BookId) };
                availableBooksGridView.Rows.Add(row);
            }

            var allBooks = WalletService.GetBooks();

            if (!genreComboBox.Items.Contains("All")) genreComboBox.Items.Add("All");
            foreach (var book in allBooks)
            {
                if (book.Other.Genre != null && !genreComboBox.Items.Contains(book.Other.Genre))
                {
                    genreComboBox.Items.Add(book.Other.Genre);
                }
            }
        }

        private void FrontPageButton_Click(object sender, EventArgs e)
        {
            FrontPage page = new FrontPage(userId);
            Hide();
            page.ShowDialog();
            Close();
        }

        private void WalletButton_Click(object sender, EventArgs e)
        {
            WalletForm wallet = new WalletForm(userId);
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
                    object[] row = { book.Item1.Author, book.Item1.Title, WalletService.GetDaysRemaining(book.Item1.BookId, userId), BookService.GetBookPrice(book.Item1.BookId) };
                    availableBooksGridView.Rows.Add(row);
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
                    object[] row = { book.Item1.Author, book.Item1.Title, WalletService.GetDaysRemaining(book.Item1.BookId, userId), BookService.GetBookPrice(book.Item1.BookId) };
                    if (book.Item1.Other.Genre == selectedGenre)
                    {
                        availableBooksGridView.Rows.Add(row);
                    }
                }
            }
        }
    }
}
