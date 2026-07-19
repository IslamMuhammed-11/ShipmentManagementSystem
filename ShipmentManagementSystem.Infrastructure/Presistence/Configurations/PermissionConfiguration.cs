using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Permission");

        builder.HasIndex(e => e.Name, "UQ_Permission_Name").IsUnique();

        builder.Property(e => e.Name).HasMaxLength(100);
    }
}

