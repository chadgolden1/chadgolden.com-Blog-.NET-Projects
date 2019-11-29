using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EFCore;
using Microsoft.EntityFrameworkCore;

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
