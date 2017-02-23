
// Houssem Dellai
// houssem.dellai@live.com
// @HoussemDellai
// +216 95 325 964

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskList_Service
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;

        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public GenericRepository()
        {
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }

        //public async Task<TEntity> GetByIdAsync(int id)
        //{
        //    return await DbSet.FindAsync(id);
        //}

        public TEntity GetById(int id)
        {
            return  DbSet.Find(id);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void EditAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
             _dbContext.SaveChanges();
        }

        public void  InsertAsync(TEntity entity)
        {

            DbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void  DeleteAsync(TEntity entity)
        {
         DbSet.Attach(entity);
            DbSet.Remove(entity);
             _dbContext.SaveChanges();
        }
    }
}