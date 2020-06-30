using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        // methods for finding retrieving entities from a collection 
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // method for adding entities to a collection 
        TEntity Add(TEntity entity);
        TEntity AddRange(IEnumerable<TEntity> entities);

        // method for removing entities from a collection 
        TEntity Remove(TEntity entity);
        TEntity RemoveRange(IEnumerable<TEntity> entities);
    }
}
