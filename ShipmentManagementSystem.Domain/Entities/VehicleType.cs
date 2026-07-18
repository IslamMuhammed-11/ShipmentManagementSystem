using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class VehicleType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
