using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Driver
{
    public int UserId { get; set; }

    public string LicenseNumber { get; set; } = null!;

    public string AvailabilityStatus { get; set; } = null!;

    public virtual ICollection<DriverLocationPing> DriverLocationPings { get; set; } = new List<DriverLocationPing>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
