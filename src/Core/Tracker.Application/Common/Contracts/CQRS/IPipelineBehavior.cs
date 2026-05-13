namespace Tracker.Application.Common.Contracts.CQRS;

public delegate Task<TResult> RequestHandlerDelegate<TResult>();

public interface IPipelineBehavior<TRequest, TResponse>
{
    Task<TResponse> HandleAsync(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);
}
