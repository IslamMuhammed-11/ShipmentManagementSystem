using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        
            builder.HasKey(e => e.UserId).HasName("PK_Customer");

            builder.HasIndex(e => e.CompanyName, "IX_Customer_CompanyName");

            builder.Property(e => e.UserId).ValueGeneratedNever();
            builder.Property(e => e.CompanyName).HasMaxLength(200);

            builder.HasOne(d => d.User).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .HasConstraintName("FK_Customer_User");
    }
}

