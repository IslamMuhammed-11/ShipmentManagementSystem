using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class DriverLocationPingConfiguration : IEntityTypeConfiguration<DriverLocationPing>
{
    public void Configure(EntityTypeBuilder<DriverLocationPing> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_DriverLocationPing");
        
        builder.HasIndex(e => new { e.DriverId, e.Timestamp }, "IX_DriverLocationPing_DriverId_Timestamp");
        
        builder.Property(e => e.Timestamp).HasDefaultValueSql("(sysutcdatetime())");
        
        builder.OwnsOne(e => e.Coordinates, coordinates =>
        {
            coordinates.Property(c => c.Latitude).HasColumnName("Latitude").IsRequired();
            coordinates.Property(c => c.Longitude).HasColumnName("Longitude").IsRequired();
        });

        builder.HasOne(d => d.Driver).WithMany(p => p.DriverLocationPings)
            .HasForeignKey(d => d.DriverId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_DriverLocationPing_Driver");
    }
}

