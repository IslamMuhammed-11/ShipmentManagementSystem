using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {

            builder.HasKey(e => e.Id).HasName("PK_Vehicle");

            builder.HasIndex(e => e.CurrentDriverId, "IX_Vehicle_CurrentDriverId");

            builder.HasIndex(e => e.VehicleNumber, "UQ_Vehicle_VehicleNumber").IsUnique();

            builder.Property(e => e.Capacity).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            builder.Property(e => e.VehicleNumber).HasMaxLength(30);

            builder.HasOne(d => d.CurrentDriver).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.CurrentDriverId)
                .HasConstraintName("FK_Vehicle_Driver");

            builder.HasOne(d => d.VehicleTypeNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_VehicleType");

    }
}
