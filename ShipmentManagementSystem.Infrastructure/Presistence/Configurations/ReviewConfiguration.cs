using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {

        builder.HasKey(e => e.Id).HasName("PK_Review");

        builder.HasIndex(e => e.ShipmentId, "UQ_Review_ShipmentId").IsUnique();

        builder.Property(e => e.Comment).HasMaxLength(1000);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

        builder.Property(e => e.Rating).IsRequired();
        builder.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Customer");

        builder.HasOne(d => d.Shipment).WithOne(p => p.Review)
            .HasForeignKey<Review>(d => d.ShipmentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Review_Shipment");
    }
}
