using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

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

            builder.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
    }
}
