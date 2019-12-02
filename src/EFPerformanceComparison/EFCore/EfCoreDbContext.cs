using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFCore
{
    public class EfCoreDbContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Copy> Copy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\msSqlLocalDB; Integrated Security=True; Database=EfCoreBookDB; MultipleActiveResultSets=true;"
                );

    }

    public class Book
    {

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
