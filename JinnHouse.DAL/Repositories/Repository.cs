using JinnHouse.DAL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext db)
        {
            this.DbSet = db.Set<T>();
        }

        private DbSet<T> DbSet { get; }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0,
            int take = -1)
        {
            IQueryable<T> query = this.DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = orderBy?.Invoke(query) ?? query;

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            if (take > 0)
            {
                query = query.Take(take);
            }

            return query.ToList();
        }

        public virtual int Count(Func<T, bool> filter = null)
        {
            return filter == null
                ? this.DbSet.Count()
                : this.DbSet.Count(filter);
        }

        public virtual void Insert(T entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Delete(T entityToDelete)
        {
            this.DbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            this.DbSet.Attach(entityToUpdate);
        }
    }
}
