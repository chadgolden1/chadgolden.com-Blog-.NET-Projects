using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using EF6;
using EFCore;
using System;
using System.Linq;

namespace EF.Benchmark
{
    [SimpleJob(RunStrategy.Throughput, launchCount: 1, warmupCount: 5, targetCount: 50)]
    [MedianColumn]
    public class AddRemoveAndDeleteRecordBenchmark
    {
        [Benchmark]
        public void AddWithEf6()
        {
            using var ef6 = new Ef6DbContext();

            var newAuthor = new EF6.Author()
            {
                FullName = "Adding Author with EF6"
            };

            ef6.Authors.Add(newAuthor);

            ef6.SaveChanges();
        }

        [Benchmark]
        public void UpdateWithEf6()
        {
            using var ef6 = new Ef6DbContext();

            var authorToUpdate = ef6.Authors.First();

            authorToUpdate.FullName = DateTime.Now.ToString();

            ef6.SaveChanges();
        }

        [Benchmark]
        public void DeleteWithEf6()
        {
            using var ef6 = new Ef6DbContext();

            var authorToDelete = ef6.Authors
                .Where(author => author.FullName == "Adding Author with EF6")
                .FirstOrDefault();

            ef6.Authors.Remove(authorToDelete);

            ef6.SaveChanges();
        }

        [Benchmark]
        public void AddWithEfCore()
        {
            using var efCore = new EfCoreDbContext();

            var newAuthor = new EFCore.Author()
            {
                FullName = "Adding Author with EF6"
            };

            efCore.Authors.Add(newAuthor);

            efCore.SaveChanges();
        }

        [Benchmark]
        public void UpdateWithEfCore()
        {
            using var efCore = new EfCoreDbContext();

            var authorToUpdate = efCore.Authors.First();

            authorToUpdate.FullName = DateTime.Now.ToString();

            efCore.SaveChanges();
        }

        [Benchmark]
        public void DeleteWithEfCore()
        {
            using var efCore = new EfCoreDbContext();

            var authorToDelete = efCore.Authors
                .Where(author => author.FullName == "Adding Author with EF6")
                .FirstOrDefault();

            efCore.Authors.Remove(authorToDelete);

            efCore.SaveChanges();
        }
    }
}
