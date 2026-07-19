using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {

        builder.HasKey(e => new { e.CustomerId, e.AddressId }).HasName("PK_CustomerAddress");

        builder.Property(e => e.Label).HasMaxLength(50);

        builder.Property(e => e.IsDefault).HasDefaultValue(false);

        builder.HasOne(d => d.Address).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_CustomerAddress_Address");

        builder.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("FK_CustomerAddress_Customer");

    }
}

