using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {

        builder.Property(e => e.City).HasMaxLength(100);
        builder.Property(e => e.Country).HasMaxLength(100);
        builder.Property(e => e.Governorate).HasMaxLength(100);
        builder.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
        builder.Property(e => e.Line1).HasMaxLength(200);
        builder.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
        builder.Property(e => e.PostalCode).HasMaxLength(20);
    }
}
