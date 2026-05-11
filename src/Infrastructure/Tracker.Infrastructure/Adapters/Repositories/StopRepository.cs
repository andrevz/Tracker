using Tracker.Application.Common.Contracts.Repositories;
using Tracker.Domain.Entities;
using Tracker.Infrastructure.Configurations.Persistence.Context;

namespace Tracker.Infrastructure.Adapters.Repositories;

internal class StopRepository(TrackerDbContext context) : BaseRepository<Stop>(context), IStopRepository
{
}
