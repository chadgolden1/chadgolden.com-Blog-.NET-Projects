using BenchmarkDotNet.Attributes;
using EF6;
using EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BenchmarkDotNet.Engines;

namespace EF.Benchmark
{
    [SimpleJob(RunStrategy.Throughput, launchCount: 1, warmupCount: 5, targetCount: 20)]
    public class AddRemoveDeleteNAuthors
    {
        const int N = 2500;

        [Benchmark]
        public void AddNAuthorsToEf6()
        {
            using var ef6 = new Ef6DbContext();

            var authors = new List<EF6.Author>();
            for (int i = 0; i < N; i++)
            {
                authors.Add(new EF6.Author()
                {
                    FullName = "New Author " + i
                });
            }

            ef6.Authors.AddRange(authors);

            ef6.SaveChanges();
        }

        [Benchmark]
        public void LoadAndUpdateNAuthorsWithEf6()
        {
            using var ef6 = new Ef6DbContext();

            foreach (var author in ef6.Authors.Take(N))
            {
                author.FullName = DateTime.Now.ToString();
            }

            ef6.SaveChanges();
        }
        
        [Benchmark]
        public void LoadAndDeleteNAuthorsWithEf6()
        {
            using var ef6 = new Ef6DbContext();

            var authors = ef6
                .Authors
                .Where(author => author.FullName.StartsWith("New Author"))
                .Take(N)
                .ToList();

            ef6.Authors.RemoveRange(authors);
            ef6.SaveChanges();
        }

        [Benchmark]
        public void AddNAuthorToEfCore()
        {
            using var efCore = new EfCoreDbContext();

            var authors = new List<EFCore.Author>();
            for (int i = 0; i < N; i++)
            {
                authors.Add(new EFCore.Author()
                {
                    FullName = "New Author " + i
                });
            }

            efCore.AddRange(authors);

            efCore.SaveChanges();
        }

        [Benchmark]
        public void LoadAndUpdateNAuthorsWithEfCore()
        {
            using var efCore = new EfCoreDbContext();

            foreach (var author in efCore.Authors.Take(N))
            {
                author.FullName = DateTime.Now.ToString();
            }

            efCore.SaveChanges();
        }

        [Benchmark]
        public void LoadAndDeleteNAuthorsWithEfCore()
        {
            using var efCore = new EfCoreDbContext();

            var authors = efCore
                .Authors
                .Where(author => author.FullName.StartsWith("New Author"))
                .Take(N)
                .ToList();

            efCore.Authors.RemoveRange(authors);
            efCore.SaveChanges();
        }
    }
}
