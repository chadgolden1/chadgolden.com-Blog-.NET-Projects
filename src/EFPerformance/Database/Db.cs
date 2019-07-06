using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFPerformance.Database
{
    public class Db : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Copy> Copy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=BooksDB;Trusted_Connection=True;");

    }

    public class Book {

        public int BookId { get; set; }
        public string Name { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual IList<Copy> Copies { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }
    }

    public class Copy
    {
        public int CopyId { get; set; }
        public virtual Book Book { get; set; }
        public decimal Price { get; set; }
    }
}
