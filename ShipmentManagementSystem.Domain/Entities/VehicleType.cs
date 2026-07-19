using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class VehicleType
{
    public int Id { get; init; }

    public string Name { get; init; } = null!;

    private VehicleType()
    {
    }

    private VehicleType(string name)
    {
        Name = name;
    }

    public static VehicleType Create(string name)
    {
        return new VehicleType(name);
    }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
