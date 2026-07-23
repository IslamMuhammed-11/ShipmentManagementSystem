using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasKey(e => e.Id).HasName("PK_User");

        builder.HasIndex(e => e.Email, "IX_User_Email");

        builder.HasIndex(e => e.RoleId, "IX_User_RoleId");

        builder.HasIndex(e => e.Email, "UQ_User_Email").IsUnique();

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        builder.Property(e => e.Email).HasMaxLength(200);
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.PasswordHash).HasMaxLength(512);
        builder.Property(e => e.PhoneNumber).HasMaxLength(30);
        builder.Property(e => e.ProfileImageUrl).HasMaxLength(500);

        builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(e => e.SecondName).HasMaxLength(50);
        builder.Property(e => e.ThirdName).HasMaxLength(50);
        builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();

        builder.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
    }
}
