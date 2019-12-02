using EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EF.Benchmark.Helpers
{
    public class EfCoreHelper
    {
        private readonly EfCoreDbContext _efCore;

        public EfCoreHelper(EfCoreDbContext efCore)
        {
            _efCore = efCore;
        }

        public List<Book> LoadAllBooksWithAuthors()
        {
            return _efCore.Books.Include(book => book.Author).ToList();
        }
    }
}
