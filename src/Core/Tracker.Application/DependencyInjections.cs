using Microsoft.Extensions.DependencyInjection;
using Tracker.Application.Common.Contracts.CQRS;
using Tracker.Application.Common.Contracts.Services.CQRS;
using Tracker.Application.Common.Services.CQRS;
using Tracker.Application.Features.Stops.GetAll.DTO;
using Tracker.Application.Features.Stops.GetAll.Handler;
using Tracker.Application.Features.Stops.GetAll.Query;
using Tracker.Application.Features.Stops.Update.Command;
using Tracker.Application.Features.Stops.Update.Handler;
using Tracker.Domain.Common;

namespace Tracker.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDispatcher, Dispatcher>();

        services.AddScoped<IQueryHandler<GetAllStopsQuery, Result<IEnumerable<GetAllStopResponse>>>, GetAllStopsQueryHandler>();
        services.AddScoped<ICommandHandler<UpdateStopCommand, Result>, UpdateStopCommandHandler>();
        
        return services;
    }
}
