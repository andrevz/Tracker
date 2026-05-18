using Tracker.Application.Common.Contracts.Services.Persistence;
using Tracker.Infrastructure.Configurations.Persistence.Context;

namespace Tracker.Infrastructure.Services;

internal class UnitOfWork(TrackerDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}
