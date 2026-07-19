using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {



            builder.HasKey(e => e.Id).HasName("PK_Shipment");

            builder.HasIndex(e => e.AssignedDriverId, "IX_Shipment_AssignedDriverId");

            builder.HasIndex(e => e.CreatedAt, "IX_Shipment_CreatedAt");

            builder.HasIndex(e => e.CurrentStatus, "IX_Shipment_CurrentStatus");

            builder.HasIndex(e => e.CustomerId, "IX_Shipment_CustomerId");

            builder.HasIndex(e => e.TrackingNumber, "UQ_Shipment_TrackingNumber").IsUnique();
            
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            builder.Property(e => e.CurrentStatus)
                .HasMaxLength(30)
                .HasDefaultValue("Created");
            builder.Property(e => e.PackageDescription).HasMaxLength(500);
            builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.TrackingNumber).HasMaxLength(30);
            builder.Property(e => e.WeightKg).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.ApprovedByEmployee).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.ApprovedByEmployeeId)
                .HasConstraintName("FK_Shipment_Employee");

            builder.HasOne(d => d.AssignedDriver).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.AssignedDriverId)
                .HasConstraintName("FK_Shipment_Driver");

            builder.HasOne(d => d.AssignedVehicle).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.AssignedVehicleId)
                .HasConstraintName("FK_Shipment_Vehicle");

            builder.HasOne(d => d.CurrentWarehouse).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.CurrentWarehouseId)
                .HasConstraintName("FK_Shipment_Warehouse");

            builder.HasOne(d => d.Customer).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Customer");

            builder.HasOne(d => d.DeliveryAddress).WithMany(p => p.ShipmentDeliveryAddresses)
                .HasForeignKey(d => d.DeliveryAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_DeliveryAddress");

            builder.HasOne(d => d.PickupAddress).WithMany(p => p.ShipmentPickupAddresses)
                .HasForeignKey(d => d.PickupAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_PickupAddress");


    }
}
