using JinnHouse.DAL.EFHouseContext;
using JinnHouse.DAL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly HouseContext db;

        private bool disposed = false;

        public EFUnitOfWork(HouseContext context)
        {
            this.db = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(this.db);
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
