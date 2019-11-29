using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EF.Benchmark.Helpers;
using BenchmarkDotNet.Attributes;

namespace EF.Benchmark
{
    public class LoadAllBooksWithAuthorsBenchmark : EfBenchmark
    {
        [Benchmark]
        public List<EF6.Book> LoadAllBooksWithAuthorsWithEf6()
        {
            return new Ef6Helper(_ef6).LoadAllBooksWithAuthors();
        }

        [Benchmark]
        public List<EFCore.Book> LoadAllBooksWithAuthorsWithEfCore()
        {
            return new EfCoreHelper(_efCore).LoadAllBooksWithAuthors();
        }   
    }
}
