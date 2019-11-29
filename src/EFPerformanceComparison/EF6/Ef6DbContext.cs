using System.Collections.Generic;
using System.Data.Entity;

namespace EF6
{
    public class Ef6DbContext : DbContext
    {
        public Ef6DbContext() : base(@"Server=(localdb)\msSqlLocalDB; Integrated Security=True; Database=Ef63BookDB; MultipleActiveResultSets=true;")
            { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Copy> Copy { get; set; }
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
