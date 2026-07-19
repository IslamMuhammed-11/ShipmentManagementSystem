using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Shipment
{
    public int Id { get; init; }

    public string TrackingNumber { get; init; } = null!;

    public int CustomerId { get; init; }

    public int PickupAddressId { get; private set; }

    public int DeliveryAddressId { get; private set; }

    public string? PackageDescription { get; private set; }

    public decimal WeightKg { get; init; }

    public decimal Price { get; init; }

    public int? AssignedDriverId { get; private set; }

    public int? AssignedVehicleId { get; private set; }

    public int? CurrentWarehouseId { get; private set; }

    public int? ApprovedByEmployeeId { get; init; }

    public string CurrentStatus { get; private set; } = null!;

    public DateTime CreatedAt { get; init; }

    private Shipment()
    {
    }

    private Shipment(string trackingNumber, int customerId, int pickupAddressId, int deliveryAddressId, string? packageDescription,
        decimal weightKg, decimal price, int? assignedDriverId, int? assignedVehicleId, int? currentWarehouseId,
        int? approvedByEmployeeId, string currentStatus, DateTime createdAt)
    {
        TrackingNumber = trackingNumber;
        CustomerId = customerId;
        PickupAddressId = pickupAddressId;
        DeliveryAddressId = deliveryAddressId;
        PackageDescription = packageDescription;
        WeightKg = weightKg;
        Price = price;
        AssignedDriverId = assignedDriverId;
        AssignedVehicleId = assignedVehicleId;
        CurrentWarehouseId = currentWarehouseId;
        ApprovedByEmployeeId = approvedByEmployeeId;
        CurrentStatus = currentStatus;
        CreatedAt = createdAt;
    }


    public static Shipment Create(string trackingNumber, int customerId, int pickupAddressId, int deliveryAddressId, string? packageDescription,
        decimal weightKg, decimal price, int? assignedDriverId, int? assignedVehicleId, int? currentWarehouseId,
        int? approvedByEmployeeId, string currentStatus, DateTime createdAt)
    {

        if(customerId is 0 || pickupAddressId is 0 || deliveryAddressId is 0 || string.IsNullOrWhiteSpace(trackingNumber) || string.IsNullOrWhiteSpace(currentStatus))
        {
            throw new ArgumentException("Invalid shipment data");
        }

        return new Shipment(trackingNumber, customerId, pickupAddressId, deliveryAddressId, packageDescription,
            weightKg, price, assignedDriverId, assignedVehicleId, currentWarehouseId,
            approvedByEmployeeId, currentStatus, createdAt);
    }

    public void UpdateStatus(string newStatus)
    {
        CurrentStatus = newStatus;
    }

    public void AssignDriver(int driverId)
    {
        AssignedDriverId = driverId;
    }

    public void AssignVehicle(int vehicleId)
    {
        AssignedVehicleId = vehicleId;
    }

    public void UpdateCurrentWarehouse(int? warehouseId)
    {
        CurrentWarehouseId = warehouseId;
    }

    public virtual Employee? ApprovedByEmployee { get; private set; }

    public virtual Driver? AssignedDriver { get; private set; }

    public virtual Vehicle? AssignedVehicle { get; private set; }

    public virtual Warehouse? CurrentWarehouse { get; private set; }

    public virtual Customer Customer { get; private set; } = null!;

    public virtual Address DeliveryAddress { get; private set; } = null!;

    public virtual DeliveryProof? DeliveryProof { get; private set; }

    public virtual ICollection<Payment> Payments { get; private set; } = new List<Payment>();

    public virtual Address PickupAddress { get; private set; } = null!;

    public virtual Review? Review { get; private set; }

    public virtual ICollection<ShipmentTracking> ShipmentTrackings { get; private set; } = new List<ShipmentTracking>();
}
