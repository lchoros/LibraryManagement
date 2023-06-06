using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public class BookCopy
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public bool IsCheckedOut { get; set; }
        public Book Book { get; set; }
    }
}
