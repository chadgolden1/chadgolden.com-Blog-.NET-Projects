using EF6;
using EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Benchmark
{
    public class EfBenchmark : IDisposable
    {
        protected readonly Ef6DbContext _ef6;
        protected readonly EfCoreDbContext _efCore;

        public EfBenchmark()
        {
            _ef6 = new Ef6DbContext();
            _efCore = new EfCoreDbContext();
        }

        public virtual void Dispose()
        {
            _ef6.Dispose();
            _efCore.Dispose();
        }
    }
}
