using BenchmarkDotNet.Running;
using System;

namespace EF.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<FindById>();
            //BenchmarkRunner.Run<FirstAndSingleOrDefaultBenchmark>();
            //BenchmarkRunner.Run<LoadAllBooksWithAuthorsBenchmark>();
            BenchmarkRunner.Run<AddRemoveDeleteNAuthors>();
        }
    }
}
