using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Vehicle
{
    public int Id { get; set; }

    public string VehicleNumber { get; set; } = null!;

    public int VehicleType { get; set; }

    public decimal Capacity { get; set; }

    public int? CurrentDriverId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Driver? CurrentDriver { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual VehicleType VehicleTypeNavigation { get; set; } = null!;
}
