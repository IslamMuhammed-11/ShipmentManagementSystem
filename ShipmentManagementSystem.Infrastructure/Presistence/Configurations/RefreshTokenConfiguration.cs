using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_RefreshToken");

        builder.HasIndex(e => e.UserId, "IX_RefreshToken_UserId");

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        builder.Property(e => e.TokenHash).HasMaxLength(512);
        builder.Property(e=> e.IsRevoked).HasDefaultValue(false);
        builder.Property(e => e.ExpiresAt).HasDefaultValueSql("(dateadd(day,(7),(sysutcdatetime())))");

        builder.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_RefreshToken_User");
    }
}

