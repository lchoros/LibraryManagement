using LibraryManagement.Core.Entities;
using LibraryManagement.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data.DbContexts
{
    public class LibraryContext : IdentityDbContext<User>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors{get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
    }
}