using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notification");

        builder.HasKey(e => e.Id).HasName("PK_Notification");

        builder.HasIndex(e => new { e.UserId, e.IsRead }, "IX_Notification_UserId_IsRead");
        
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        builder.Property(e => e.Message).HasMaxLength(500);
        builder.Property(e => e.Type).HasMaxLength(50);
        builder.Property(e => e.IsRead).HasDefaultValue(false);

        builder.HasOne(d => d.User).WithMany(p => p.Notifications)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Notification_User");
    }
}

