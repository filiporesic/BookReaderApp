using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookReaderApp
{
    internal class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email; 
            PasswordHash = PasswordManager.ComputeSha256Hash(password);
        }

        public User() { }
    }
    
}
