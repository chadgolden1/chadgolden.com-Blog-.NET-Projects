using EF6;
using EFCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EF.Create
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateEf6Db();
            CreateEfCoreDb();

            Console.WriteLine("Complete.");
        }

        static void CreateEf6Db()
        {
            using var context = new Ef6DbContext();
            bool isEf6Created = context.Database.Exists();

            // Create our database and seed data if it doesn't exist.
            if (!isEf6Created)
            {
                Console.WriteLine($"Creating EF6 Database on {context.Database.Connection.ConnectionString}");
                context.Database.Create();
            }
            else
            {
                Console.WriteLine("Skipping creation of Ef6 database. It already exists.");
            }

            Console.WriteLine("EF6 complete.");
        }

        static void CreateEfCoreDb()
        {
            using var context = new EfCoreDbContext();
            bool isEfCoreCreated = context.Database.CanConnect();

            if (!isEfCoreCreated)
            {
                Console.WriteLine($"Creating EF Core Database on {context.Database.GetDbConnection().ConnectionString}");
                context.Database.EnsureCreated();
            }
            else
            {
                Console.WriteLine("Skipping creation of Ef Core database. It already exists.");
            }

            Console.WriteLine("EF Core complete.");
        }
    }
}
