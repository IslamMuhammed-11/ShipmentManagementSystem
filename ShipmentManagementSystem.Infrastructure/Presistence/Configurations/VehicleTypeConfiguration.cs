using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

internal class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
    {

        builder.HasKey(e => e.Id).HasName("PK__VehicleT__3214EC07575DC830");

        builder.HasIndex(e => e.Name, "UQ_VehicleTypes_Name").IsUnique();

        builder.Property(e => e.Name).HasMaxLength(20);
    }
}
