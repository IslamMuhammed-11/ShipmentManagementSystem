using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Payment");

        builder.HasIndex(e => e.ShipmentId, "IX_Payment_ShipmentId");

        builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
        builder.Property(e => e.Method).HasMaxLength(20);
        builder.Property(e => e.Status)
            .HasMaxLength(20)
            .HasDefaultValue("Pending");
        builder.Property(e => e.TransactionId).HasMaxLength(100);
        builder.Property(e => e.PaymentDate).HasColumnType("datetime2");

        builder.HasOne(d => d.Shipment).WithMany(p => p.Payments)
            .HasForeignKey(d => d.ShipmentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Payment_Shipment");
    }
}

