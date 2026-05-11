using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Domain.Entities;

namespace Tracker.Infrastructure.Configurations.Persistence.Entities;

public class StopConfiguration : IEntityTypeConfiguration<Stop>
{
    public void Configure(EntityTypeBuilder<Stop> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.OwnsOne(s => s.Location, location =>
        {
            location.Property(l => l.Latitude)
                .HasColumnName("Latitude")
                .IsRequired();

            location.Property(l => l.Longitude)
                .HasColumnName("Longitude")
                .IsRequired();
        });

        builder.Property(s => s.DisplayOrder)
            .IsRequired();
    }
}
