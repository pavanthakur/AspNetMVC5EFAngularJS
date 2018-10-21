using EH.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace EH.DAL.Interface
{
    public interface IBaseRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        T Find<T>(int id) where T : class;
        Task<T> FindAsync<T>(Expression<Func<T, bool>> match) where T : class;
        Task<List<T>> FindAllAsync<T>() where T : class;
        IQueryable<T> Query<T>() where T : class;
        Task<List<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        void SaveChanges();
        Task<int> SaveChangesAsync();
        void Dispose();
    }    

    public interface IApplicationRepository : IBaseRepository
    {
        ApplicationDbContext _dbContext { get; }
    }
}
