using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderApp
{
    internal static class WalletService
    {
        public static Wallet GetWallet(int userId)
        {
            string query = "SELECT userId, amount FROM Wallets where userId = @userId";

            string name = "userId";
            object value = userId;
            var dt = DatabaseService.SelectData(query, name, value);

            if(dt.Rows.Count > 0 )
            {
                DataRow row = dt.Rows[0];
                Wallet wallet = new Wallet((int)row["userId"], (decimal)row["amount"]);

                return wallet;
            }
            else
            {
                throw new Exception("No wallet found with id " +  userId);
            }
        }

        public static void UpdateWallet(int userId, decimal amount)
        {
            string query = "UPDATE Wallets SET amount = @amount WHERE userID = @userId";

            string[] names = {"amount", "userId"};
            object[] values = {amount, userId};

            DatabaseService.UpdateQuery(query, names, values);
        }

        public static void DepositToWallet(int userId, decimal amount)
        {
            decimal currentAmount = GetWallet(userId).Amount;
            decimal newAmount = currentAmount + amount;
            UpdateWallet(userId, newAmount);
        }

        public static void WithdrawToBankAccount(int userId, decimal amount)
        {
            decimal currentAmount = GetWallet(userId).Amount;
            decimal newAmount = currentAmount - amount;
            UpdateWallet(userId, newAmount);
        }

        public static List<BookOwnership> GetAllBorrowedBooks(int userId)
        {
            List<BookOwnership> books = new List<BookOwnership>();

            string query = "SELECT userId, bookId, dateBorrowed FROM BookOwnership where userId = @userId";

            string name = "userId";
            object value = userId;
            var dt = DatabaseService.SelectData(query, name, value);

            foreach(DataRow row in dt.Rows)
            {
                books.Add(new BookOwnership((int)row["userId"],
                          (int)row["bookId"], (DateTime)row["dateBorrowed"]));
            }

            return books;
        }

        public static List<BookOwnership> GetActiveBorrowedBooks(int userId)
        {
            List<BookOwnership> books = new List<BookOwnership>();

            string query = "SELECT userId, bookName, BorrowDate FROM BookOwnership where userId = @userId" +
                "WHERE (DATE(BorrowDate) > (CURDATE() - INTERVAL 1 MONTH) AND BorrowDate < (CURDATE() + INTERVAL 12 HOUR)) " +
                "OR (DATE(BorrowDate) = (CURDATE() - INTERVAL 1 MONTH) AND HOUR(BorrowDate) >= 13)";

            string name = "userId";
            object value = userId;
            var dt = DatabaseService.SelectData(query, name, value);

            foreach (DataRow row in dt.Rows)
            {
                books.Add(new BookOwnership((int)row["userId"],
                          (int)row["bookId"], (DateTime)row["BorrowDate"]));
            }

            return books;
        }

        public static List<Transaction> GetTransactions(int walletId)
        {
            List<Transaction> transactions = new List<Transaction>();

            string query = "SELECT transactionId, userId, bookId, amount, borrowDate, returnDate FROM Transactions where walletId = @walletId";

            string name = "walletId";
            object value = walletId;
            var dt = DatabaseService.SelectData(query, name, value);

            foreach (DataRow row in dt.Rows)
            {
                transactions.Add(new Transaction((int)row["userId"], walletId,
                          (int)row["bookId"], (decimal)row["amount"], (DateTime)row["borrowDate"]));
            }

            return transactions;
        }

        public static Dictionary<string, decimal> GetBooksWithPrices()
        {
            Dictionary<string, decimal> bookPricePairs = new Dictionary<string, decimal>();

            string query = "SELECT price, title FROM Books";

            var dt = DatabaseService.SelectData(query);

            foreach (DataRow row in dt.Rows)
            {
                bookPricePairs.Add((string)row["title"], (decimal)row["price"]);
            }

            return bookPricePairs;
        }

        public static Dictionary<int, Tuple<string, string>> GetBorrowedBooks(int userId)
        {
            Dictionary<int, Tuple<string, string>> books = new Dictionary<int, Tuple<string, string>>();

            string query = "SELECT bookId FROM Transactions WHERE userId = @userId AND current_date < returnDate";

            string name = "userId";
            object value = userId;
            var dt = DatabaseService.SelectData(query, name, value);

            foreach (DataRow row in dt.Rows)
            {
                books.Add((int)row["bookId"], BookService.GetBookTitleAndAuthor((int)row["bookId"]));
            }

            return books;
        }
    }
}
