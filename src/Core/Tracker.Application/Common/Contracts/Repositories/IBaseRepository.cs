using Tracker.Domain.Common;

namespace Tracker.Application.Common.Contracts.Repositories;

public interface IBaseRepository<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAllSync();
}
