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
        public string Genre { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Book() { }

        public Book(int bookId, string title, string author, string genre, string description, decimal price)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            Genre = genre;
            Description = description;
            Price = price;
        }

    }
}
