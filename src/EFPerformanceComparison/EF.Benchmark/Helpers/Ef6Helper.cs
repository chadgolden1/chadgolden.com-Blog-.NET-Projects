using EF6;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EF.Benchmark.Helpers
{
    public class Ef6Helper
    {
        private readonly Ef6DbContext _ef6;

        public Ef6Helper(Ef6DbContext ef6)
        {
            _ef6 = ef6;
        }

        public List<Book> LoadAllBooksWithAuthors()
        {
            return _ef6.Books.Include(book => book.Author).ToList();
        }
    }
}
