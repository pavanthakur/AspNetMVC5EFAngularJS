using EH.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EH.DAL.Repository
{
    public abstract class BaseRepository : IBaseRepository, IDisposable
    {
        private bool disposed = false;

        private DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Generic

        public IQueryable<T> Query<T>() where T : class
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public virtual async Task<List<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync<T>();
        }

        public T Find<T>(int id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual async Task<T> FindAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(match);
        }

        public virtual async Task<List<T>> FindAllAsync<T>() where T : class
        {
            return await _dbContext.Set<T>().ToListAsync<T>();
        }

        public void Add<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public virtual async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async virtual Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    DisposeSub();
                }
                this.disposed = true;
            }
        }

        protected virtual void DisposeSub()
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    public static class GenericRepositoryExtensions
    {
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> queryable, Expression<Func<T, TProperty>> relatedEntity) where T : class
        {
            return System.Data.Entity.QueryableExtensions.Include<T, TProperty>(queryable, relatedEntity);
        }
    }
}
