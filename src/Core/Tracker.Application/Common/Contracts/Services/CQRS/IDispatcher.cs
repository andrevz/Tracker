using Tracker.Application.Common.Contracts.CQRS;

namespace Tracker.Application.Common.Contracts.Services.CQRS;

public interface IDispatcher
{
    Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : IQuery<TResult>;
}
