using Microsoft.Extensions.DependencyInjection;
using Tracker.Application.Common.Contracts.CQRS;
using Tracker.Application.Common.Contracts.Services.CQRS;

namespace Tracker.Application.Common.Services.CQRS;

public class Dispatcher(IServiceProvider provider) : IDispatcher
{
    public Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : IQuery<TResult>
    {
        var handler = provider.GetRequiredService<IQueryHandler<TQuery, TResult>>()
            ?? throw new InvalidOperationException($"No handler found for query of type {typeof(TQuery).FullName}");

        return handler.HandleAsync(query, cancellationToken);
    }
}
