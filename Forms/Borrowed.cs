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
            availableBooksGridView.ClearSelection();
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
                object[] row = { book.Item1.BookId, book.Item1.Title, book.Item1.Author, WalletService.GetDaysRemaining(book.Item1.BookId, userId) };
                availableBooksGridView.Rows.Add(row);
            }

            List<Book> allBooks = WalletService.GetBooks();

            if (!genreComboBox.Items.Contains("All")) genreComboBox.Items.Add("All");
            foreach (Book book in allBooks)
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
                    object[] row = { book.Item1.Title, book.Item1.Author, WalletService.GetDaysRemaining(book.Item1.BookId, userId) };
                    availableBooksGridView.Rows.Add(row);
                }


                List<Book> allBooks = WalletService.GetBooks();

                if (!genreComboBox.Items.Contains("All")) genreComboBox.Items.Add("All");
                foreach (Book book in allBooks)
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
                        if (uniqueBooks[book.BookId].Item2 < daysRemaining)
                        {
                            uniqueBooks[book.BookId] = (book, daysRemaining);
                        }
                    }
                    else
                    {
                        if (book.Other.Genre == selectedGenre)
                        {
                            uniqueBooks.Add(book.BookId, (book, daysRemaining));
                        }
                    }
                }

                foreach (var book in uniqueBooks.Values)
                {
                    object[] row = { book.Item1.BookId, book.Item1.Title, book.Item1.Author, WalletService.GetDaysRemaining(book.Item1.BookId, userId) };
                    availableBooksGridView.Rows.Add(row);
                }
            }
        }

        private void AvailableBooksGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = availableBooksGridView.SelectedCells[0].RowIndex;
            int bookId = (int)availableBooksGridView.Rows[row].Cells[0].Value;

            string filename = "..\\..\\" + BookService.GetBookLocation(bookId);

            pdfViewer1.LoadFromFile(filename);
        }

        private void AvailableBooksGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int bookId = (int)availableBooksGridView.Rows[e.RowIndex].Cells[0].Value;
                string title = (string)availableBooksGridView.Rows[e.RowIndex].Cells[1].Value;
                string author = (string)availableBooksGridView.Rows[e.RowIndex].Cells[2].Value;
                BookDetails details = BookService.GetBookDetails(bookId);
                using (InfoForm transferForm = new InfoForm(details, author, title))
                {
                    if (transferForm.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
        }
    }
}
