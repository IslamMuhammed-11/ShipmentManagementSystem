using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Warehouse
{
    public int Id { get; init; }

    public string Name { get; private set; } = null!;

    public int AddressId { get; init; }

    public decimal Capacity { get; private set; }

    public string Status { get; private set; } = null!;

    private Warehouse()
    {
    }


    private Warehouse(string name, int addressId, decimal capacity, string status)
    {
        Name = name;
        AddressId = addressId;
        Capacity = capacity;
        Status = status;
    }

    public static Warehouse Create(string name, int addressId, decimal capacity, string status)
    {
        return new Warehouse(name, addressId, capacity, status);
    }


    public void UpdateStatus(string status)
    {
        Status = status;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateCapacity(decimal capacity)
    {
        Capacity = capacity;
    }

    public virtual Address Address { get; private set; } = null!;

    public virtual ICollection<ShipmentTracking> ShipmentTrackings { get; set; } = new List<ShipmentTracking>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
