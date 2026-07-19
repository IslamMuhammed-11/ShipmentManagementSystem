using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class DeliveryProofConfiguration : IEntityTypeConfiguration<DeliveryProof>
{
    public void Configure(EntityTypeBuilder<DeliveryProof> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_DeliveryProof");
        
        builder.HasIndex(e => e.ShipmentId, "UQ_DeliveryProof_ShipmentId").IsUnique();
        
        builder.Property(e => e.DeliveredAt).HasDefaultValueSql("(sysutcdatetime())");
        builder.Property(e => e.DeliveryNotes).HasMaxLength(500);
        builder.Property(e => e.ProofImageUrl).HasMaxLength(500);
        builder.Property(e => e.ReceiverName).HasMaxLength(150);
        builder.Property(e => e.SignatureUrl).HasMaxLength(500);
        
        builder.HasOne(d => d.Shipment).WithOne(p => p.DeliveryProof)
            .HasForeignKey<DeliveryProof>(d => d.ShipmentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_DeliveryProof_Shipment");
    }
}

