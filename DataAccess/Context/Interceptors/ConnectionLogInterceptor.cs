

using Microsoft.EntityFrameworkCore.Diagnostics;
using Service.ServicesAbstractions;
using System.Data.Common;

namespace DataAccess.Context.Interceptors
{
    //  💖 Interceptors is used to hook EF core actions
    //          like querying and connecting, we even can
    //          redo sql query 🌈
    //
    //  ᓚᘏᗢ Interceptors is scoped(new interceptor per dbContext instance)
    public class ConnectionLogInterceptor : ISaveChangesInterceptor
    {
        private readonly ILogService logService;

        public ConnectionLogInterceptor(ILogService logService)
        {
            this.logService = logService;
        }

        public void SaveChangesFailed(DbContextErrorEventData eventData)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesFailedAsync(DbContextErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            await logService.LogAsync($"{eventData.EntitiesSavedCount} entities were saved! ");
            return result;
        }

        public InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await logService.LogAsync($"{DateTime.Now} entities is being saved!");
            return result;
        }
    }
}
