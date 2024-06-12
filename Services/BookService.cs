using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookReaderApp
{
    internal static class BookService
    {
        public static Book GetBook(int bookId)
        {
            string query = "SELECT * FROM Books where bookId = @bookId";

            string name = "bookId";
            object value = bookId;
            var dt = DatabaseService.SelectData(query, name, value);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Book book = new Book((int)row["bookId"], (string)row["Title"], (string)row["Author"], (string)row["Other"], (decimal)row["Price"]);
                return book;
            }
            else
            {
                throw new Exception("No book found with id " + bookId);
            }
        }

        public static string GetBookTitle(int bookId)
        {
            string query = "SELECT Title FROM Books where bookId = @bookId";

            string name = "bookId";
            object value = bookId;
            var dt = DatabaseService.SelectData(query, name, value);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Title"].ToString();
            }
            else
            {
                throw new Exception("No book found with id " + bookId);
            }
        }

        public static decimal GetBookPrice(int bookId)
        {
            string query = "SELECT Price FROM Books where bookId = @bookId";

            string name = "bookId";
            object value = bookId;
            var dt = DatabaseService.SelectData(query, name, value);

            if (dt.Rows.Count > 0)
            {
                return (decimal)dt.Rows[0]["Price"];
            }
            else
            {
                throw new Exception("No book found with id " + bookId);
            }
        }

        public static Tuple<string, string> GetBookTitleAndAuthor(int bookId)
        {

            string query = "SELECT Title, Author FROM Books where bookId = @bookId";

            string name = "bookId";
            object value = bookId;
            var dt = DatabaseService.SelectData(query, name, value);

            if (dt.Rows.Count > 0)
            {
                return new Tuple<string, string>(dt.Rows[0]["Title"].ToString(), dt.Rows[0]["Author"].ToString());
            }
            else
            {
                throw new Exception("No book found with id " + bookId);
            }
        }

        public static string GetBookLocation(int bookId)
        {

            string query = "SELECT BookLocation -> @bookId as Location FROM BookLocations";

            string name = "bookId";
            string value = bookId.ToString();
            var dt = DatabaseService.SelectData(query, name, value);

            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    if(row["Location"].ToString() != "")
                    {
                        return row["Location"].ToString();
                    }
                }
                throw new Exception("No book found with id " + bookId);
            }
            else
            {
                throw new Exception("No book found with id " + bookId);
            }
        }

        public static BookDetails GetBookDetails(int bookId)
        {
            string query = "SELECT Other FROM Books where bookId = @bookId";

            string name = "bookId";
            object value = bookId;
            var dt = DatabaseService.SelectData(query, name, value);

            if (dt.Rows.Count > 0)
            {
                BookDetails details = JsonSerializer.Deserialize<BookDetails>((string)dt.Rows[0]["other"]);
                return details;
            }
            else
            {
                throw new Exception("No book found with id " + bookId);
            }
        }
    }
}
