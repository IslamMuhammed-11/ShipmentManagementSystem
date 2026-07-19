using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.UserId).HasName("PK_Employee");
        
        builder.Property(e => e.UserId).ValueGeneratedNever();
        builder.Property(e => e.Department).HasMaxLength(100);
        
        builder.HasOne(d => d.User).WithOne(p => p.Employee)
            .HasForeignKey<Employee>(d => d.UserId)
            .HasConstraintName("FK_Employee_User");
    }
}

