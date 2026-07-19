using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {

        builder.HasKey(e => e.Id).HasName("PK_Role");

        builder.HasIndex(e => e.Name, "UQ_Role_Name").IsUnique();

        builder.Property(e => e.Name).HasMaxLength(50);

        builder.HasMany(d => d.Permissions).WithMany(p => p.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "RolePermission",
                r => r.HasOne<Permission>().WithMany()
                    .HasForeignKey("PermissionId")
                    .HasConstraintName("FK_RolePermission_Permission"),
                l => l.HasOne<Role>().WithMany()
                    .HasForeignKey("RoleId")
                    .HasConstraintName("FK_RolePermission_Role"),
                j =>
                {
                    j.HasKey("RoleId", "PermissionId").HasName("PK_RolePermission");
                    j.ToTable("RolePermissions");
                });

    }
}
