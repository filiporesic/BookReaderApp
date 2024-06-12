using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderApp.Data
{
    internal class BookDetails
    {
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Description { get; set; }

        public BookDetails() { }
        public BookDetails(string genre, int releaseYear, string description)
        {
            Genre = genre;
            ReleaseYear = releaseYear;
            Description = description;
        }
    }
}
