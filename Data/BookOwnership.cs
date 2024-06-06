using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderApp
{
    internal class BookOwnership
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime Date { get; set; }

        public BookOwnership() { }

        public BookOwnership(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
            Date = DateTime.Now;
        }

        public BookOwnership(int userId, int bookId, DateTime date)
        {
            UserId = userId;
            BookId = bookId;
            Date = date;
        }
    }
}
