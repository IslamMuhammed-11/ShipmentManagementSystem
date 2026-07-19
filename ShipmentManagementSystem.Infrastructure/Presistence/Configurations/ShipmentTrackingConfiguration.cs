using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class ShipmentTrackingConfiguration : IEntityTypeConfiguration<ShipmentTracking>
{
    public void Configure(EntityTypeBuilder<ShipmentTracking> builder)
    {

            builder.HasKey(e => e.Id).HasName("PK_ShipmentTracking");

            builder.HasIndex(e => new { e.ShipmentId, e.Timestamp }, "IX_ShipmentTracking_ShipmentId_Timestamp");

            
            builder.Property(e => e.Notes).HasMaxLength(500);
            builder.Property(e => e.Status).HasMaxLength(30);
            builder.Property(e => e.Timestamp).HasDefaultValueSql("(sysutcdatetime())");

            builder.OwnsOne(e => e.Coordinates, cb =>
            {
                cb.Property(c => c.Latitude).HasColumnName("Latitude").HasColumnType("decimal(9,6)");
                cb.Property(c => c.Longitude).HasColumnName("Longitude").HasColumnType("decimal(9,6)");
            });

        builder.HasOne(d => d.Shipment).WithMany(p => p.ShipmentTrackings)
                .HasForeignKey(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentTracking_Shipment");

            builder.HasOne(d => d.Warehouse).WithMany(p => p.ShipmentTrackings)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_ShipmentTracking_Warehouse");
    }
}
