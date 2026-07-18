using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Warehouse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AddressId { get; set; }

    public decimal Capacity { get; set; }

    public string Status { get; set; } = null!;

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<ShipmentTracking> ShipmentTrackings { get; set; } = new List<ShipmentTracking>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
