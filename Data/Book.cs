using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderApp
{
    internal class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public Book() { }

        public Book(int bookId, string title, string author, decimal price)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            Price = price;
        }
    }
}
