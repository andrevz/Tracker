using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Tracker.Infrastructure.Configurations.Persistence.Context;

public class TrackerDbContextFactory : IDesignTimeDbContextFactory<TrackerDbContext>
{
    public TrackerDbContext CreateDbContext(string[] args)
    {
        var connectionString = "Host=localhost;Port=5432;Database=trackerdb;Username=postgres;Password=postgres";

        var optionsBuilder = new DbContextOptionsBuilder<TrackerDbContext>();
        optionsBuilder.UseNpgsql(connectionString, options =>
        {
            options.MigrationsHistoryTable("__EFMigrationHistory", "public");
        });

        return new TrackerDbContext(optionsBuilder.Options);
    }
}