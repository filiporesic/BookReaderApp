using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                User user = new User();
                user.UserId =(int) row["UserID"];
                user.Username =(string) row["Username"];
                user.PasswordHash =(string) row["PasswordHash"];
                user.Email =(string) row["Email"];

                return user;
            }
            else
            {
                throw new Exception("No user found with username " +  username);
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

    }
}