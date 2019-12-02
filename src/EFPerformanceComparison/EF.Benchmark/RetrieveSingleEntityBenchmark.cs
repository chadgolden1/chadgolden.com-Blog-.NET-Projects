using BenchmarkDotNet.Attributes;
using System.Linq;

namespace EF.Benchmark
{
    public class RetriveSingleEntityBenchmark : EfBenchmark
    {
        [Benchmark]
        public EF6.Book FirstOrDefaultWithEf6() =>
            _ef6.Books.FirstOrDefault();

        [Benchmark]
        public EFCore.Book FirstOrDefaultWithEfCore() =>
            _efCore.Books.FirstOrDefault();
    }
}
