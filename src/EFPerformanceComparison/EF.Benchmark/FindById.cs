using BenchmarkDotNet.Attributes;
using EF6;
using EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Benchmark
{
    [MinColumn, MaxColumn]
    public class FindById : EfBenchmark
    {
        [Benchmark]
        public EF6.Book FindWithEf6() => _ef6.Books.Find(1);

        [Benchmark]
        public EFCore.Book FindWithEfCore() => _efCore.Books.Find(1);
    }
}
