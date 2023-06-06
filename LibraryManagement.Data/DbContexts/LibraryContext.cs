using LibraryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data.DbContexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors{get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
    }
}