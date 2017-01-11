using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.DAL.Interfaces.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0,
            int take = -1);

        int Count(Func<T, bool> filter = null);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entityToDelete);
    }
}
