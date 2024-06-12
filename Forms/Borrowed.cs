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
    }
}
