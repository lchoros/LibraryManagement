using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public  class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public string Synopsis { get; set; }
        public string Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public ICollection<BookCopy> Copies { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}