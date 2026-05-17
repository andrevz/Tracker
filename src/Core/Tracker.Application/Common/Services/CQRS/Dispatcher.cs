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

    public Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
    {
        var handler = provider.GetRequiredService<ICommandHandler<TCommand>>()
            ?? throw new InvalidOperationException($"No handler found for command of type {typeof(TCommand).FullName}");

        return handler.HandleAsync(command, cancellationToken);
    }

    public async Task<TResult> SendAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand<TResult>
    {
        var handler = provider.GetRequiredService<ICommandHandler<TCommand, TResult>>()
            ?? throw new InvalidOperationException($"No handler found for command of type {typeof(TCommand).FullName}");

        var behaviors = provider.GetService<IEnumerable<IPipelineBehavior<TCommand, TResult>>>()?.ToArray() 
            ?? Enumerable.Empty<IPipelineBehavior<TCommand, TResult>>();

        RequestHandlerDelegate<TResult> handlerDelegate = () => handler.HandleAsync(command, cancellationToken);

        var pipeline = behaviors.Reverse().Aggregate(handlerDelegate, (next, behavior) =>
        {
            return () => behavior.HandleAsync(command, next, cancellationToken);
        });

        return await pipeline();
    }
}
