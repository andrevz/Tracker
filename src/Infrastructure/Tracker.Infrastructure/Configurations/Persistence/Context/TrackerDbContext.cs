using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Entities;

namespace Tracker.Infrastructure.Configurations.Persistence.Context;

public class TrackerDbContext(DbContextOptions<TrackerDbContext> options) : DbContext(options)
{
    public DbSet<Stop> Stops => Set<Stop>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrackerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
