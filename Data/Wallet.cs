using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderApp
{
    internal class Wallet
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }

        public Wallet() { }

        public Wallet(int walletId, int userId, string currencyCode = "EUR")
        {
            WalletId = walletId;
            UserId = userId;
            CurrencyCode = currencyCode;
            Amount = 0;
        }

        public Wallet(int walletId, int userId, decimal amount, string currencyCode = "EUR")
        {
            WalletId = walletId;
            UserId = userId;
            CurrencyCode = currencyCode;
            Amount = amount;
        }
    }
}
