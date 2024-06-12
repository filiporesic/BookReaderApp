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

            var allBooks = WalletService.GetBooks();

            borrowBooksGridView.DataSource = allBooks;
            borrowBooksGridView.Columns["BookId"].Visible = false;
            borrowBooksGridView.Columns["Other"].Visible = false;
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


    }
}
