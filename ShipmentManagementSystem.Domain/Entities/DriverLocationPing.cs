using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class DriverLocationPing
{
    public int Id { get; set; }

    public int DriverId { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual Driver Driver { get; set; } = null!;
}
