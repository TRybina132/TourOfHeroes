using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync(
            bool asNoTracking = true,
            int skip = 0,
            int? take = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Expression<Func<T,bool>>? filter = null);
        Task<T?> GetById(
            int id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
