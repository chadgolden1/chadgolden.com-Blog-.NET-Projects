using EFPerformance.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace EFPerformance
{
    /// <summary>
    /// Console application to test some EF Core performance concepts.
    /// Nothing fancy...
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();

            LazyVsEagerLoadingExample(timer);
            EFToListTest(timer);

            Console.ReadLine();
        }

        static void LazyLoadingExample(Stopwatch timer)
        {
            var take = 1000;

            using (var db = new Db())
            {
                timer.Restart();

                var books = db.Books
                    .OrderBy(b => b.BookId)
                    .Take(take)
                    .ToList();
                
                foreach (var book in books)
                {
                    var doSomethingWithName = book.Author.FullName;
                }
                
                timer.Stop();
                Console.Write("Lazy loading: ");
                PrintElapsed(timer);
            }
        }

        static void EagerLoadingExample(Stopwatch timer)
        {
            var take = 1000;

            using (var db = new Db())
            {
                timer.Restart();

                var books = db.Books
                    .Include(b => b.Author)
                    .OrderBy(b => b.BookId)
                    .Take(take)
                    .ToList();
                
                foreach (var book in books)
                {
                    var doSomethingWithName = book.Author.FullName;
                }

                timer.Stop();
                Console.Write("Eager loading: ");
                PrintElapsed(timer);
            }
        }

        static void ProjectionExample(Stopwatch timer)
        {
            var take = 1000;

            using (var db = new Db())
            {
                timer.Restart();

                var books = db.Books
                    .OrderBy(b => b.BookId)
                    .Take(take)
                    .Select(b => new
                    {
                        b.Author.FullName
                    })
                    .ToList();

                foreach (var book in books)
                {
                    var doSomethingWithName = book.FullName;
                }

                timer.Stop();
                Console.Write("Projection: ");
                PrintElapsed(timer);
            }
        }

        static void LazyVsEagerLoadingExample(Stopwatch timer)
        {
            var N = 13;

            for (var numberOfTests = 0; numberOfTests < N; ++numberOfTests)
            {
                LazyLoadingExample(timer);
            }

            for (var numberOfTests = 0; numberOfTests < N; ++numberOfTests)
            {
                EagerLoadingExample(timer);
            }

            for (var numberOfTests = 0; numberOfTests < N; ++numberOfTests)
            {
                ProjectionExample(timer);
            }
        }

        static void LoadInMemory(Stopwatch timer)
        {
            using (var db = new Db())
            {
                timer.Restart();

                var books = db.Books.ToList();

                var matchingBooks = books
                    .Where(b => b.Name == "EF Core for Smarties");
                
                timer.Stop();
                PrintElapsed(timer);
            }
        }

        static void LoadInDb(Stopwatch timer)
        {
            using (var db = new Db())
            {
                timer.Restart();

                var books = db.Books
                    .Where(b => b.Name == "EF Core for Smarties")
                    .ToList();
                
                timer.Stop();
                PrintElapsed(timer);
            }
        }

        static void EFToListTest(Stopwatch timer)
        {
            Console.WriteLine("In memory:");
            for (var numberOfTests = 0; numberOfTests < 13; ++numberOfTests)
            {
                LoadInMemory(timer);
            }

            Console.WriteLine("In DB:");
            for (var numberOfTests = 0; numberOfTests < 13; ++numberOfTests)
            {
                LoadInDb(timer);
            }
        }

        static void PrintElapsed(Stopwatch timer)
        {
            Console.WriteLine($"Finished in {timer.ElapsedMilliseconds}ms");
        }
    }
}
