using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(e => e.UserId).HasName("PK_Driver");

        builder.HasIndex(e => e.LicenseNumber, "UQ_Driver_LicenseNumber").IsUnique();

        builder.Property(e => e.UserId).ValueGeneratedNever();
        builder.Property(e => e.AvailabilityStatus)
            .HasMaxLength(20)
            .HasDefaultValue("Offline");
        builder.Property(e => e.LicenseNumber).HasMaxLength(50);

        builder.HasOne(d => d.User).WithOne(p => p.Driver)
            .HasForeignKey<Driver>(d => d.UserId)
            .HasConstraintName("FK_Driver_User");
    }
}

