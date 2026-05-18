using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracker.Application.Common.Contracts.Repositories;
using Tracker.Application.Common.Contracts.Services.Persistence;
using Tracker.Infrastructure.Adapters.Repositories;
using Tracker.Infrastructure.Configurations.Persistence.Context;
using Tracker.Infrastructure.Services;

namespace Tracker.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TrackerDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("TrackerDB"));
        });

        services.AddScoped<IStopRepository, StopRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}
