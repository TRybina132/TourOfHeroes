using DataAccess.Context;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly TourContext tourContext;
        protected readonly DbSet<T> dbSet;

        public Repository(TourContext tourContext)
        {
            this.tourContext = tourContext;
            dbSet = tourContext.Set<T>();
        }

        public async Task<IList<T>> GetAllAsync(
            bool asNoTracking = true, int skip = 0,
            int? take = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = filter == null ?
                dbSet : dbSet.Where(filter);

            if (include != null)
                query = include(query);

            if (asNoTracking)
                query = query.AsNoTracking();

            query = query.Skip(skip);

            if (take is not null)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }

        public async Task<T?> GetById(
            int id, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            T? result = await dbSet.FindAsync(id);

            if (include == null)
                return result;

            IQueryable<T> set = include(dbSet);

            return await set.FirstOrDefaultAsync(entity => entity == result);
        }

        public void Delete(T entity) =>
            dbSet.Remove(entity);

        public async Task InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            if (tourContext.Entry(entity).State == EntityState.Detached)
                tourContext.Attach(entity);

            tourContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync() =>
            await tourContext.SaveChangesAsync();
    }
}
