using Microsoft.EntityFrameworkCore;
using Tracker.Application.Common.Contracts.Repositories;
using Tracker.Domain.Common;
using Tracker.Infrastructure.Configurations.Persistence.Context;

namespace Tracker.Infrastructure.Adapters.Repositories;

internal abstract class BaseRepository<TEntity>(TrackerDbContext context) : IBaseRepository<TEntity> where TEntity : Entity
{
    public async Task<IEnumerable<TEntity>> GetAllSync()
    {
        return await context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
    }
}
