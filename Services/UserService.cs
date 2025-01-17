using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookReaderApp
{
    internal class UserService
    {
        public static User GetUserByName(string username)
        {
            string query ="SELECT * FROM Users WHERE Username = @username";
            
            string name = "username";
            object value = username;
            var dt = DatabaseService.SelectData(query, name, value);

            if(dt.Rows.Count > 0 )
            {
                DataRow row = dt.Rows[0];
                User user = new User
                {
                    UserId = (int)row["UserID"],
                    Username = (string)row["Username"],
                    PasswordHash = (string)row["PasswordHash"],
                    Email = (string)row["Email"],
                    Balance = (decimal)row["Wallet"]
                };

                return user;
            }
            else
            {
                return new User();
            }
        }

        public static void CreateUser(User newuser)
        {
            string[] names = {"username, email, passwordhash"};
            string[] values = {newuser.Username, newuser.Email, newuser.PasswordHash};

            string query = "INSERT INTO Users (Username, Email, PasswordHash) VALUES (@username, @email, @passwordhash)";

            DatabaseService.RunQuery(query, names, values);

            return;
        }

        public static User LogIn(string username, string password)
        {
            User lgin = GetUserByName(username);
            if (lgin == new User() )
            {
                return null;
            }
            if (PasswordManager.VerifyPasswordHash(password, lgin.PasswordHash))
                return lgin;
            else
                return null;
        }

    }
}