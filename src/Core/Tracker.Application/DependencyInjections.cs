using Microsoft.Extensions.DependencyInjection;
using Tracker.Application.Common.Contracts.Services.CQRS;
using Tracker.Application.Common.Services.CQRS;

namespace Tracker.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDispatcher, Dispatcher>();
        
        return services;
    }
}
