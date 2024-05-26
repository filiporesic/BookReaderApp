using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderApp
{
    internal class Transaction
    {
        public int TransactionId { get; set; }
        public int WalletId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Transaction() { }

        public Transaction(int walletId, string title, decimal amount)
        {
            WalletId = walletId;
            Title = title;
            Amount = amount;
            BorrowDate = DateTime.UtcNow;
            ReturnDate = DateTime.UtcNow.AddMonths(1);
        }

    }
}
