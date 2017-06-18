using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.Repository;
using System.Data.Entity;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit() => Context?.SaveChanges();

        public void Dispose() => Context?.Dispose();
    }
}