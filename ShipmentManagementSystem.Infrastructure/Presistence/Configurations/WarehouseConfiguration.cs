using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

internal class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {

        builder.HasKey(e => e.Id).HasName("PK_Warehouse");

        builder.HasIndex(e => e.Name, "IX_Warehouse_Name");

        builder.HasIndex(e => e.AddressId, "UQ_Warehouse_AddressId").IsUnique();

        builder.HasIndex(e => e.Status, "IX_Warehouse_Status");

        builder.Property(e => e.Capacity).HasColumnType("decimal(10, 2)");

        builder.Property(e => e.Name).HasMaxLength(150);

        builder.Property(e => e.Status)
            .HasMaxLength(20)
            .HasDefaultValue("Active");

        builder.HasOne(d => d.Address).WithOne(p => p.Warehouse)
            .HasForeignKey<Warehouse>(d => d.AddressId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Warehouse_Address");
    }
}
