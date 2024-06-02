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
            string query = "SELECT * FROM Wallets where userId = @userId";

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

            string query = "SELECT userId, bookName, dateBorrowed FROM BookOwnership where userId = @userId";

            string name = "userId";
            object value = userId;
            var dt = DatabaseService.SelectData(query, name, value);

            foreach(DataRow row in dt.Rows)
            {
                books.Add(new BookOwnership((int)row["userId"], 
                          row["bookName"].ToString(), (DateTime)row["dateBorrowed"]));
            }

            return books;
        }

        public static List<BookOwnership> GetActiveBorrowedBooks(int userId)
        {
            List<BookOwnership> books = new List<BookOwnership>();

            string query = "SELECT userId, bookName, dateBorrowed FROM BookOwnership where userId = @userId" +
                "WHERE (DATE(dateBorrowed) > LAST_DAY(CURDATE() - INTERVAL 1 MONTH) AND dateBorrowed < (CURDATE() + INTERVAL 12 HOUR)) " +
                "OR (DATE(dateBorrowed) = LAST_DAY(CURDATE() - INTERVAL 1 MONTH) AND HOUR(dateBorrowed) >= 13)";

            string name = "userId";
            object value = userId;
            var dt = DatabaseService.SelectData(query, name, value);

            foreach (DataRow row in dt.Rows)
            {
                books.Add(new BookOwnership((int)row["userId"],
                          row["bookName"].ToString(), (DateTime)row["dateBorrowed"]));
            }

            return books;
        }

    }
}
