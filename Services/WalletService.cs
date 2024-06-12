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

        public static void DepositToWallet(int userId, decimal amount)
        {
            decimal currentAmount = GetBalance(userId);
            decimal newAmount = currentAmount + amount;
            UpdateWallet(userId, newAmount);
        }

        public static decimal GetBalance(int userId)
        {
            string query = "SELECT Wallet FROM Users where userId = @userId";

            string name = "userId";
            object value = userId;
            var dt = DatabaseService.SelectData(query, name, value);

            if (dt.Rows.Count > 0)
            {
                return (decimal)dt.Rows[0]["wallet"];
            }
            else
            {
                throw new Exception("No user found with id " + userId);
            }
        }

        public static void UpdateWallet(int userId, decimal amount)
        {
            string query = "UPDATE Users SET wallet = @amount WHERE userID = @userId";

            string[] names = { "amount", "userId" };
            object[] values = { amount, userId };

            DatabaseService.RunQuery(query, names, values);
        }

        public static List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            string query = "SELECT bookId, Title, Author, Other, Price FROM Books";

            var dt = DatabaseService.SelectData(query);

            foreach (DataRow row in dt.Rows)
            {
                books.Add(new Book((int)row["bookId"], (string)row["Title"], (string)row["Author"],(string)row["Other"], (decimal)row["Price"]));
            }

            return books;
        }
        public static List<Transaction> GetTransactions(int userId)
        {
            List<Transaction> transactions = new List<Transaction>();

            string query = "SELECT transactionId, bookId, amount, borrowDate, returnDate FROM Transactions where userId = @userId";

            string name = "userId";
            object value = userId;
            var dt = DatabaseService.SelectData(query, name, value);

            foreach (DataRow row in dt.Rows)
            {
                transactions.Add(new Transaction((int)row["transactionId"], userId,
                          (int)row["bookId"], (decimal)row["amount"], (DateTime)row["borrowDate"], (DateTime)row["returnDate"]));
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

        public static List<Tuple<int, string, string>> GetBorrowedBooks(int userId)
        {
            List<Tuple<int, string, string>> books = new List<Tuple<int, string, string>>();

            string query = "SELECT bookId FROM Transactions WHERE userId = @userId AND current_date < returnDate";

            string name = "userId";
            object value = userId;
            var dt = DatabaseService.SelectData(query, name, value);

            foreach (DataRow row in dt.Rows)
            {
                books.Add(new Tuple<int, string, string>((int)row["bookId"], 
                    (BookService.GetBookTitleAndAuthor((int)row["bookId"]).Item1), (BookService.GetBookTitleAndAuthor((int)row["bookId"]).Item2)));
            }

            return books;
        }

        public static int GetDaysRemaining(int bookId, int userId)
        {
            string query = "SELECT returnDate FROM Transactions where bookId = @bookId AND userId = @userID AND current_date < returnDate";

            string[] name = {"bookId", "userId" };
            object[] value = {bookId, userId};
            var dt = DatabaseService.SelectData(query, name, value);



            if (dt.Rows.Count > 0)
            {
                DateTime returnDate = (DateTime)dt.Rows[0]["returnDate"];
                int daysRemaining = (int)(returnDate - DateTime.Today).TotalDays;
                foreach (DataRow row in dt.Rows)
                {
                    if ((int)((DateTime)row["returnDate"] - DateTime.Today).TotalDays > daysRemaining)
                        daysRemaining = (int)((DateTime)row["returnDate"] - DateTime.Today).TotalDays;
                }

                return daysRemaining;
            }
            else
            {
                throw new Exception("No book found with id " + bookId);
            }
        }

        public static void CreateTransaction(int bookId, int userId, decimal amount, DateTime returnDate)
        {
            string query = "INSERT INTO transactions (userid, bookid, amount, borrowdate, returndate) VALUES (@userId, @bookId, @amount, @borrowDate, @returnDate);";

            string[] name = {"bookId", "userId", "amount", "borrowDate", "returnDate"};
            object[] value = {bookId, userId, amount, DateTime.Now.Date, returnDate.Date};

            DatabaseService.RunQuery(query, name, value);
        }

    }
}
