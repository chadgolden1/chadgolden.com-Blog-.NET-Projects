using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace EF.Benchmark
{
    public class FirstAndSingleOrDefaultBenchmark : EfBenchmark
    {
        [Benchmark]
        public EF6.Book FirstOrDefaultWithEf6() => 
            _ef6.Books.FirstOrDefault(book => book.BookId == 1);

        [Benchmark]
        public EF6.Book SingleOrDefaultWithEf6() =>
            _ef6.Books.SingleOrDefault(book => book.BookId == 1);

        [Benchmark]
        public EFCore.Book FirstOrDefaultWithEfCore() => 
            _efCore.Books.FirstOrDefault(book => book.BookId == 1);

        [Benchmark]
        public EFCore.Book SingleOrDefaultWithEfCore() =>
            _efCore.Books.SingleOrDefault(book => book.BookId == 1);
    }
}
