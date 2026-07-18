using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Infrastructure.Presistence;

public partial class LogisticsShipmentDbContext : DbContext
{
    public LogisticsShipmentDbContext()
    {
    }

    public LogisticsShipmentDbContext(DbContextOptions<LogisticsShipmentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<DeliveryProof> DeliveryProofs { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriverLocationPing> DriverLocationPings { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<ShipmentTracking> ShipmentTrackings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleType> VehicleTypes { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=LogisticsShipmentDb;User Id=sa; Password=sa123456;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {




        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.AddressId }).HasName("PK_CustomerAddress");

            entity.Property(e => e.Label).HasMaxLength(50);

            entity.HasOne(d => d.Address).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_CustomerAddress_Address");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerAddress_Customer");
        });

        modelBuilder.Entity<DeliveryProof>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DeliveryProof");

            entity.HasIndex(e => e.ShipmentId, "UQ_DeliveryProof_ShipmentId").IsUnique();

            entity.Property(e => e.DeliveredAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DeliveryNotes).HasMaxLength(500);
            entity.Property(e => e.ProofImageUrl).HasMaxLength(500);
            entity.Property(e => e.ReceiverName).HasMaxLength(150);
            entity.Property(e => e.SignatureUrl).HasMaxLength(500);

            entity.HasOne(d => d.Shipment).WithOne(p => p.DeliveryProof)
                .HasForeignKey<DeliveryProof>(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeliveryProof_Shipment");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Driver");

            entity.HasIndex(e => e.LicenseNumber, "UQ_Driver_LicenseNumber").IsUnique();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.AvailabilityStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Offline");
            entity.Property(e => e.LicenseNumber).HasMaxLength(50);

            entity.HasOne(d => d.User).WithOne(p => p.Driver)
                .HasForeignKey<Driver>(d => d.UserId)
                .HasConstraintName("FK_Driver_User");
        });

        modelBuilder.Entity<DriverLocationPing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DriverLocationPing");

            entity.HasIndex(e => new { e.DriverId, e.Timestamp }, "IX_DriverLocationPing_DriverId_Timestamp");

            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Timestamp).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Driver).WithMany(p => p.DriverLocationPings)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DriverLocationPing_Driver");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Employee");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Department).HasMaxLength(100);

            entity.HasOne(d => d.User).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.UserId)
                .HasConstraintName("FK_Employee_User");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.HasIndex(e => new { e.UserId, e.IsRead }, "IX_Notification_UserId_IsRead");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Notification_User");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Payment");

            entity.HasIndex(e => e.ShipmentId, "IX_Payment_ShipmentId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Method).HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TransactionId).HasMaxLength(100);

            entity.HasOne(d => d.Shipment).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Shipment");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Permission");

            entity.HasIndex(e => e.Name, "UQ_Permission_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RefreshToken");

            entity.HasIndex(e => e.UserId, "IX_RefreshToken_UserId");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.TokenHash).HasMaxLength(512);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_RefreshToken_User");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Review");

            entity.HasIndex(e => e.ShipmentId, "UQ_Review_ShipmentId").IsUnique();

            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Customer");

            entity.HasOne(d => d.Shipment).WithOne(p => p.Review)
                .HasForeignKey<Review>(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Shipment");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Role");

            entity.HasIndex(e => e.Name, "UQ_Role_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasMany(d => d.Permissions).WithMany(p => p.Roles)
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
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Shipment");

            entity.HasIndex(e => e.AssignedDriverId, "IX_Shipment_AssignedDriverId");

            entity.HasIndex(e => e.CreatedAt, "IX_Shipment_CreatedAt");

            entity.HasIndex(e => e.CurrentStatus, "IX_Shipment_CurrentStatus");

            entity.HasIndex(e => e.CustomerId, "IX_Shipment_CustomerId");

            entity.HasIndex(e => e.TrackingNumber, "UQ_Shipment_TrackingNumber").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.CurrentStatus)
                .HasMaxLength(30)
                .HasDefaultValue("Created");
            entity.Property(e => e.PackageDescription).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrackingNumber).HasMaxLength(30);
            entity.Property(e => e.WeightKg).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.ApprovedByEmployee).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.ApprovedByEmployeeId)
                .HasConstraintName("FK_Shipment_Employee");

            entity.HasOne(d => d.AssignedDriver).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.AssignedDriverId)
                .HasConstraintName("FK_Shipment_Driver");

            entity.HasOne(d => d.AssignedVehicle).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.AssignedVehicleId)
                .HasConstraintName("FK_Shipment_Vehicle");

            entity.HasOne(d => d.CurrentWarehouse).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.CurrentWarehouseId)
                .HasConstraintName("FK_Shipment_Warehouse");

            entity.HasOne(d => d.Customer).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Customer");

            entity.HasOne(d => d.DeliveryAddress).WithMany(p => p.ShipmentDeliveryAddresses)
                .HasForeignKey(d => d.DeliveryAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_DeliveryAddress");

            entity.HasOne(d => d.PickupAddress).WithMany(p => p.ShipmentPickupAddresses)
                .HasForeignKey(d => d.PickupAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_PickupAddress");
        });

        modelBuilder.Entity<ShipmentTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ShipmentTracking");

            entity.HasIndex(e => new { e.ShipmentId, e.Timestamp }, "IX_ShipmentTracking_ShipmentId_Timestamp");

            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(30);
            entity.Property(e => e.Timestamp).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Shipment).WithMany(p => p.ShipmentTrackings)
                .HasForeignKey(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentTracking_Shipment");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.ShipmentTrackings)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_ShipmentTracking_Warehouse");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.HasIndex(e => e.Email, "IX_User_Email");

            entity.HasIndex(e => e.RoleId, "IX_User_RoleId");

            entity.HasIndex(e => e.Email, "UQ_User_Email").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(512);
            entity.Property(e => e.PhoneNumber).HasMaxLength(30);
            entity.Property(e => e.ProfileImageUrl).HasMaxLength(500);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Vehicle");

            entity.HasIndex(e => e.CurrentDriverId, "IX_Vehicle_CurrentDriverId");

            entity.HasIndex(e => e.VehicleNumber, "UQ_Vehicle_VehicleNumber").IsUnique();

            entity.Property(e => e.Capacity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            entity.Property(e => e.VehicleNumber).HasMaxLength(30);

            entity.HasOne(d => d.CurrentDriver).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.CurrentDriverId)
                .HasConstraintName("FK_Vehicle_Driver");

            entity.HasOne(d => d.VehicleTypeNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_VehicleType");
        });

        modelBuilder.Entity<VehicleType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleT__3214EC07575DC830");

            entity.HasIndex(e => e.Name, "UQ_VehicleTypes_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Warehouse");

            entity.HasIndex(e => e.Name, "IX_Warehouse_Name");

            entity.HasIndex(e => e.AddressId, "UQ_Warehouse_AddressId").IsUnique();

            entity.Property(e => e.Capacity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.Address).WithOne(p => p.Warehouse)
                .HasForeignKey<Warehouse>(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_Address");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
