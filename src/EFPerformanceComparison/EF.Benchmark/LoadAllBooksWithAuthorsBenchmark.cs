using BenchmarkDotNet.Attributes;
using EF.Benchmark.Helpers;
using EF6;
using EFCore;
using System.Collections.Generic;

namespace EF.Benchmark
{
    [MedianColumn]
    public class LoadAllBooksWithAuthorsBenchmark
    {
        [Benchmark]
        public List<EF6.Book> LoadAllBooksWithAuthorsWithEf6()
        {
            using var ef6 = new Ef6DbContext();
            return new Ef6Helper(ef6).LoadAllBooksWithAuthors();
        }

        [Benchmark]
        public List<EFCore.Book> LoadAllBooksWithAuthorsWithEfCore()
        {
            using var efCore = new EfCoreDbContext();
            return new EfCoreHelper(efCore).LoadAllBooksWithAuthors();
        }
    }
}
