using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Vehicle
{
    public int Id { get; private set; }

    public string VehicleNumber { get; private set; } = null!;

    public int VehicleType { get; private set; }

    public decimal Capacity { get; private set; }

    public int? CurrentDriverId { get; private set; }

    public string Status { get; private set; } = null!;

    private Vehicle()
    {
    }

    private Vehicle(string vehicleNumber, int vehicleType, decimal capacity, int? currentDriverId, string status)
    {
        VehicleNumber = vehicleNumber;
        VehicleType = vehicleType;
        Capacity = capacity;
        CurrentDriverId = currentDriverId;
        Status = status;
    }

    public static Vehicle Create(string vehicleNumber, int vehicleType, decimal capacity, int? currentDriverId, string status)
    {
        return new Vehicle(vehicleNumber, vehicleType, capacity, currentDriverId, status);
    }

    public void AssignDriver(int driverId)
    {
        CurrentDriverId = driverId;
    }

    public void UnassignDriver()
    {
        CurrentDriverId = null;
    }

    public void UpdateStatus(string status)
    {
        Status = status;
    }

    public virtual Driver? CurrentDriver { get; private set; }

    public virtual ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    public virtual VehicleType VehicleTypeNavigation { get; private set; } = null!;
}
