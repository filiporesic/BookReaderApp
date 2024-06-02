using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderApp
{
    internal class BookOwnership
    {
        public int UserId { get; set; }
        public string BookName { get; set; }
        public DateTime Date { get; set; }

        public BookOwnership() { }

        public BookOwnership(int userId, string name)
        {
            UserId = userId;
            BookName = name;
            Date = DateTime.Now;
        }

        public BookOwnership(int userId, string name, DateTime date)
        {
            UserId = userId;
            BookName = name;
            Date = date;
        }
    }
}
