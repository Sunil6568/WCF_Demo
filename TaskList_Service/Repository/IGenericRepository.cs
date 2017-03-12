
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskList_Service
{
    public interface IGenericRepository<TEntity>
    {

     //   Task<TEntity> GetByIdAsync(int id);

TEntity  GetById(int id);

        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        void EditAsync(TEntity entity);

        void InsertAsync(TEntity entity);

        void DeleteAsync(TEntity entity);
    }
}