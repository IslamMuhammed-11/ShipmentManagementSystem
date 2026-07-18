using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Shipment
{
    public int Id { get; set; }

    public string TrackingNumber { get; set; } = null!;

    public int CustomerId { get; set; }

    public int PickupAddressId { get; set; }

    public int DeliveryAddressId { get; set; }

    public string? PackageDescription { get; set; }

    public decimal WeightKg { get; set; }

    public decimal Price { get; set; }

    public int? AssignedDriverId { get; set; }

    public int? AssignedVehicleId { get; set; }

    public int? CurrentWarehouseId { get; set; }

    public int? ApprovedByEmployeeId { get; set; }

    public string CurrentStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Employee? ApprovedByEmployee { get; set; }

    public virtual Driver? AssignedDriver { get; set; }

    public virtual Vehicle? AssignedVehicle { get; set; }

    public virtual Warehouse? CurrentWarehouse { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Address DeliveryAddress { get; set; } = null!;

    public virtual DeliveryProof? DeliveryProof { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Address PickupAddress { get; set; } = null!;

    public virtual Review? Review { get; set; }

    public virtual ICollection<ShipmentTracking> ShipmentTrackings { get; set; } = new List<ShipmentTracking>();
}
